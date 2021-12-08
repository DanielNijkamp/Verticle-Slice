using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing_Grid_Tile : MonoBehaviour
{
    private Grid_Tile grid;
    private int _placingSprite;

    void Start()
    {
         grid = new Grid_Tile(20, 14, 1f, new Vector3(0,0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), _placingSprite);
            Debug.Log("OnClick: " + true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
