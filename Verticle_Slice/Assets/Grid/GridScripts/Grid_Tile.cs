using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid_Tile 
{
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _originPosition;
    private int[,] _gridArray;
    private TextMesh[,] _debugTextArray;

    public Grid_Tile(int _width, int _height, float _cellSize, Vector3 _originPosition)
    {
        this._width = _width;
        this._width = _height;
        this._cellSize = _cellSize;
        this._originPosition = _originPosition;

        _gridArray = new int[_width, _height];
        _debugTextArray = new TextMesh[_width, _height];

        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                _debugTextArray[x,y] = UtilsClass.CreateWorldText(_gridArray[x, y].ToString(), null, GetWorldPosition(x,y) + new Vector3(_cellSize, _cellSize) * .5f, 10, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(_width, _height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(_width, 0), GetWorldPosition(_width, _height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize + _originPosition;
    }
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - _originPosition).x / _cellSize);
        y = Mathf.FloorToInt((worldPosition - _originPosition).y / _cellSize);
    }
    
    public void SetValue(int x, int y, int value)
    {
        if (x <= 0 && y <= 0 && x >= _width && y >= _height)
        {
            Debug.Log("X = " + x);
            Debug.Log("y = " + y);
            return;
        }
        else
        {
            _gridArray[x, y] = value;
            _debugTextArray[x, y].text = _gridArray[x, y].ToString() + "";
        }
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x <= 0 && y <= 0 && x >= _width && y >= _height)
        {
            return 0;
        }
        else
        {
            return _gridArray[x, y];
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
