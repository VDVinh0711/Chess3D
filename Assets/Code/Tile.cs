using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _x;
    private int _z;
    private bool _isHasChess = false;
    public int X => _x;
    public int Z => _z;
  

    public bool IsHasChess
    {
        set => this._isHasChess = value;
        get => _isHasChess;
    }

    public Tile SetPosition(int x, int z)
    {
        this._x = x;
        this._z = z;
        return this;
    }

    public void OnMouseEnter()
    {
        Debug.Log("Hover");
    }
}
