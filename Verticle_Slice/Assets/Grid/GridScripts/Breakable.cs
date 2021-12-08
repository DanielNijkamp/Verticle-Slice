using System.Collections;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [Header("Alle bool om de tool te gebruiken.")]
    private bool _oneDrop = false;
    private bool _walkThrough = false;
    [HideInInspector] public bool isPickaxe = false;
    [HideInInspector] public bool isAxe = false;
    [HideInInspector] public bool isScythe = false;
    [HideInInspector] public bool isHoe = false;

    [Header("De sprites om te controleren welke drops/animatie het heeft.")]
    [SerializeField] private Sprite[] _treeSprite;
    [SerializeField] private Sprite[] _rockSprite;
    [SerializeField] private Sprite[] _bushSprite;
    [SerializeField] private Sprite[] _logSprite;
    [SerializeField] private Sprite[] _weedSprite;

    [Header("Tree tiers.")]
    [SerializeField] private Sprite[] _tierTreeOak;
    [SerializeField] private Sprite[] _tierTreeMaple;
    [SerializeField] private Sprite[] _tierTreePine;

    private SpriteRenderer _sprite;

    [Header("Het aantal treffers dat nodig is om een ​​object te breken.")]
    [SerializeField] private float _hits;

    [Header("Wat het gameobject laat vallen")]
    public GameObject[] drops;
    public Animation[] ani;

    //"Het bedrag dat iets kan laten vallen."
    private GameObject[] _DR;
    private float _R;
    private int[] _a;
    private int[] _b;
    private string a;

    private string _array;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();

        Sprites();
    }

    public void Sprites()
    {
        for (int i = 0; i < _treeSprite.Length + 1; i++)
        {
            a = _treeSprite[i].name;

            if (_sprite.sprite.name == a)
            {
                _hits = 15;
                _R = 0.9f;
                    _a[0] = 5;
                    _b[0] = 12;
                    _a[1] = 2;
                    _b[1] = 5;
                if (i == 0)
                {
                    _DR[0] = drops[0];
                    _DR[1] = drops[1];
                }
                if (i == 1)
                {
                    _DR[0] = drops[0];
                    _DR[1] = drops[2];
                }
                if (i == 2)
                {
                    _DR[0] = drops[0];
                    _DR[1] = drops[3];
                }
                isAxe = true;
            }
        }
        for (int i = 0; i < _tierTreeOak.Length; i++)
        {
            string a;
            a = _tierTreeOak[i].name;

            if (_sprite.sprite.name == a && i == 0)
            {
                _hits = 2;
                isAxe = true;
            }
            if (_sprite.sprite.name == a && i == 1)
            {
                _hits = 1;
                isAxe = true;
            }
            if (_sprite.sprite.name == a && i == 2)
            {
                _hits = 1;
                isAxe = true;
            }
            if (_sprite.sprite.name == a && i == 3)
            {
                _hits = 1;
                isHoe = true;
            }
        }
        for (int i = 0; i < _logSprite.Length; i++)
        {
            string a;
            a = _rockSprite[i].name;
            if (_sprite.sprite.name == a)
            {
                _hits = 2;
                isAxe = true;
            }
        }
        for (int i = 0; i < _rockSprite.Length; i++)
        {
            string a;
            a = _rockSprite[i].name;
            if (_sprite.sprite.name == a)
            {
                _hits = 2;
                isPickaxe = true;
            }
        }
        for (int i = 0; i < _bushSprite.Length; i++)
        {
            string a;
            a = _bushSprite[i].name;
            if (_sprite.sprite.name == a)
            {
                _hits = 1;
                isScythe = true;
            }
        }
        for (int i = 0; i < _weedSprite.Length; i++)
        {
            string a;
            a = _weedSprite[i].name;
            if (_sprite.sprite.name == a)
            {
                _hits = 1;
                isScythe = true;
                isPickaxe = true;
                isHoe = true;
                isAxe = true;
                _walkThrough = true;
                if (_walkThrough == true)
                {
                    rb.useFullKinematicContacts = false;
                }
            }
        }
    }

    public void Tier1_4()
    {
        float rnd = Random.Range(1, 2);

        if (rnd > 1f && rnd <= 1.3f)
        {
            _sprite.sprite = _tierTreeOak[0];
        }
        if (rnd > 1.3f && rnd <= 1.7f)
        {
            _sprite.sprite = _tierTreeOak[1];
        }
        if (rnd > 1.7f && rnd <= 1.9f)
        {
            _sprite.sprite = _tierTreeOak[2];
        }
        if (rnd > 1.9f && rnd <= 2)
        {
            _sprite.sprite = _tierTreeOak[3];
        }
    }

    public void TakeDamage(float amount)
    {
        if (_hits == 15)
        {
            _hits -= amount;

            if (_hits == 5)
            {
                Drops(_DR, _R, _a, _b);

                if (a == _treeSprite[0].name)
                {
                    ani[0].Play();
                    _sprite.sprite = _treeSprite[3];
                }
                if (a == _treeSprite[1].name)
                {
                    ani[1].Play();
                    _sprite.sprite = _treeSprite[4];
                }
                if (a == _treeSprite[2].name)
                {
                    ani[2].Play();
                    _sprite.sprite = _treeSprite[5];
                }

            }
            if (_hits <= 0)
            {
                Drops(_DR, _R, _a, _b);
            }
        }
        else
        {
            _hits -= amount;

            if (_hits <= 0)
            {
                Drops(_DR, _R, _a, _b);
            }
        }
    }

    private void Drops(GameObject[] ID1, float R, int[] a, int[] b)
    {
        if (_oneDrop == true)
        {
            SpawnDrops(ID1[0], 1, 1);
            return;
        }
        float rnd = Random.Range(0,1);

        for (int i = 0; i < 2; i++)
        {
            if (rnd <= R)
            {
                SpawnDrops(ID1[0], a[0], b[0]);
            }
            if (rnd > R)
            {
                SpawnDrops(ID1[1], a[1], b[1]);
            }
        }
    }

    private void SpawnDrops(GameObject drops, int a, int b)
    {
        int rnd = Random.Range(a, b);
        int _ammountTospawn;
        float _radius = 1f;

        _ammountTospawn = rnd;

        for (int i = 0; i < _ammountTospawn; i++)
        {
            float angle = i * Mathf.PI * 2f / _ammountTospawn;
            Vector2 newPos = new Vector2(Mathf.Cos(angle) * _radius, Mathf.Sin(angle) * _radius);
            Instantiate(drops, newPos, Quaternion.identity);
        }
    }
}