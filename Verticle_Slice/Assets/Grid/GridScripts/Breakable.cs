using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [Header("Of het een wandelende hitbox heeft of niet.")]
    public bool walkThrough = false;

    [Header("Welk gereedschap het nodig heeft om te breken.")]
    public bool isPickaxe = false;
    public bool isAxe = false;
    public bool isScythe = false;
    public bool isHoe = false;

    [Header("Het aantal treffers dat nodig is om een ​​object te breken.")]
    [SerializeField]private float _hits;

    private int _ammountTospawn;
    public float radius = 1f;

    public GameObject[] drops;
    public Animator ani;
    

    void Start()
    {
        
    }

    public void TakeDamage(float amount)
    {
        _hits -= amount;

        if(_hits <= 0)
        {
            RemoveDropes();
        }
    }

    public void RemoveDropes()
    {
        StartCoroutine(Drops());
        StartCoroutine(Animation());
    }

    private IEnumerator Drops()
    {
        int rnd = Random.Range(-1, 101);

        for (int i = 0; i < 3; i++)
        {
            if (rnd <= 25)
            {
                SpawnDrops(drops[0]);
            }
            if (rnd >= 26 && rnd <= 50)
            {
                SpawnDrops(drops[1]);
            }
            if (rnd >= 51 && rnd <= 75)
            {
                SpawnDrops(drops[2]);
            }
            if (rnd >= 76 && rnd <= 100)
            {
                SpawnDrops(drops[2]);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Animation()
    {
        ani.Play("PlaceHolder");
        yield return new WaitForSeconds(ani.recorderStopTime);
        Destroy(this.gameObject);
    }

    private void SpawnDrops(GameObject drops)
    {
        int rnd = Random.Range(0, 5);

        _ammountTospawn = rnd;

        for (int i = 0; i < _ammountTospawn; i++)
        {
            float angle = i * Mathf.PI * 2f / _ammountTospawn;
            Vector2 newPos = new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
            Instantiate(drops, newPos, Quaternion.identity);
        }
    }
}
