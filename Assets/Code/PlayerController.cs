using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player[] Players = new Player[2];

    [SerializeField] private Player _currentTunrn;
    public Player CurrentTurn => _currentTunrn;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Players[0] = new Player()
        {
            ColorChess = ChessPieceColor.Black
        };
        Players[1] = new Player()
        {
            ColorChess = ChessPieceColor.White
        };
        _currentTunrn = Players[0];
    }


    public void SwitchTurn()
    {
        _currentTunrn = _currentTunrn == Players[0] ? Players[1] : Players[0];
    }
}



[System.Serializable]
public class Player
{
    public ChessPieceColor ColorChess;
    public float PlayTime = 60 * 10;
    public bool isCheck = false;
}
