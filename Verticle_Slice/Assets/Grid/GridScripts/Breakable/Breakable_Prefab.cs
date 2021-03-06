using UnityEngine;

public class Breakable_Prefab : MonoBehaviour
{
    [Header("Alle bool om de tool te gebruiken.")]
    [SerializeField] private bool _oneDrop = false;

    [SerializeField] private bool _isTree = false;
    public bool isPickaxe = false;
    public bool isAxe = false;
    public bool isScythe = false;
    public bool isHoe = false;

    [Header("De sprites om te controleren welke drops/animatie het heeft.")]
    [SerializeField] private Sprite _sprites;

    private SpriteRenderer _sprite;
    private ParticleSystem _pr;

    [Header("Het aantal treffers dat nodig is om een ​​object te breken.")]
    [SerializeField] private float _hits;

    [Header("Wat het gameobject laat vallen en animatie.")]
    public GameObject[] drops;

    public AnimationClip ani;
    private Animator _ani;

    [Header("Het bereik van elke druppel voor de objecten.")]
    [SerializeField] private float _MidR = 0.5f;

    [Header("Het bedrag dat iets kan laten vallen.")]
    [SerializeField] private int[] _a;

    [SerializeField] private int[] _b;

    private int timer = 5;
    private int timerRewind = 5;

    public void Update()
    {
        if (timer <= 0)
        {
            timer = timerRewind;
        } else
        {
            timer--;
        }
    }
    public void TakeDamage(float amount)
    {
        _ani = this.gameObject.GetComponent<Animator>();
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        if (_isTree == true)
        {
            _hits -= amount;
            _pr.Play();

            if (timer <= 0)
            {
                _ani.Play(ani.name);
            }

            if (_hits == 5)
            {
                _sprite.sprite = _sprites;
                Dropes(_MidR, _a, _b);
            }
            if (_hits <= 0)
            {
                Dropes(_MidR, _a, _b);
                Destroy(this.gameObject);
            }
        }
        else
        {
            _hits -= amount;

            if (_hits <= 0)
            {
                Dropes(_MidR, _a, _b);
                Destroy(this.gameObject);
            }
        }
    }

    private void Dropes(float A, int[] a, int[] b)
    {
        if (_oneDrop == true)
        {
            SpawnDrops(drops[0], 1, 1);
            return;
        }
        float rnd = Random.Range(0, 1);

        for (int i = 0; i < 3; i++)
        {
            if (rnd <= A)
            {
                SpawnDrops(drops[0], a[0], a[1]);
            }
            if (rnd > A)
            {
                SpawnDrops(drops[1], b[0], b[1]);
            }
        }
    }

    private void SpawnDrops(GameObject drops, int A, int B)
    {
        int rnd = Random.Range(A, B);

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