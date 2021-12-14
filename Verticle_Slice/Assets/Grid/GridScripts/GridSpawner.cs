using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSpawner : MonoBehaviour
{
    [Header("Enemy1")]
    public GameObject[] breakableObject;

    public GameObject[] treeTier;
    private GameObject _chosenObject;

    public float spawnTime = 100f;
    private int _amountSpawning = 1;
    public Tilemap tileMap;
    public List<Vector3> availablePlaces;

    private void Start()
    {
        ChoseObject();
        //Position von jedem Floortile ermitteln:
        availablePlaces = new List<Vector3>();

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    availablePlaces.Add(place);
                }
            }
        }

        if (_chosenObject != null)
        {
            StartCoroutine(SpawnObject());
        }
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            for (int i = 0; i < _amountSpawning; i++)
            {
                Instantiate(_chosenObject, availablePlaces[Random.Range(0, availablePlaces.Count)], Quaternion.identity);
            }
        }
    }

    private void ChoseObject()
    {
        float rnd = Random.Range(0, 1);
        int rnd1 = Random.Range(1, breakableObject.Length);

        if (rnd1 == 1)
        {
            if (rnd <= 0.6)
            {
                _chosenObject = treeTier[0];
            }
            if (rnd > 0.6 && rnd <= 0.8)
            {
                _chosenObject = treeTier[1];
            }
            if (rnd > 0.8 && rnd <= 0.9)
            {
                _chosenObject = treeTier[2];
            }
            if (rnd > 0.9 && rnd <= 0.95)
            {
                _chosenObject = treeTier[3];
            }
            if (rnd > 0.95)
            {
                _chosenObject = treeTier[4];
            }
            return;
        }

        if (rnd <= 0.7)
        {
            _chosenObject = breakableObject[0];
        }
        if (rnd > 0.7)
        {
            _chosenObject = breakableObject[rnd1];
        }
    }
}