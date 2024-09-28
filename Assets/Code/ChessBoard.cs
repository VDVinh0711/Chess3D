using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    private Camera _currentCamera;
    public Tile[,] pointPices = new Tile[8, 8];
    [SerializeField] private GameObject _squarePrefab;
    [SerializeField] private Transform _holder;
    private Vector2Int _currentHover;
    private List<Vector2Int> _cachesPosChange = new();
    void OnEnable()
    {
        CreateChessBoard();
    }
    
    private void GetChess(Vector2Int posInBoard)
    {
        pointPices[posInBoard.x, posInBoard.y].IsHasChess = false;
    }
    void CreateChessBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject square = Instantiate(_squarePrefab,_holder);
                square.transform.position = new Vector3(x, 0, y);
                square.transform.localScale = new Vector3(0.1f, 1, 0.1f);
                pointPices[x, y] = square.GetComponent<Tile>().SetPosition( (int)  square.transform.position.x,(int) square.transform.position.z);
                Renderer renderer = square.GetComponent<Renderer>();
                renderer.material.color = (x + y) % 2 == 0 ? SafeColor.Instance.GetColorByType(TypeColor.white)  : SafeColor.Instance.GetColorByType(TypeColor.black);
            }
        }
    }
    
    public void HighlightValidMoves( ChessPieceColor colorChessMove ,List<Vector2Int> directionShows)
    {
        
        foreach (var posTile in directionShows)
        {
            if(posTile.x < 0 || posTile.y <0) continue;
            pointPices[posTile.x,posTile.y].DisplayValidMoves(colorChessMove);
            _cachesPosChange.Add(posTile);
        }
    }

    public void ResetColorBoard()
    {
        foreach (var pos in _cachesPosChange)
        {
            Renderer renderer =  pointPices[pos.x, pos.y].transform.GetComponent<Renderer>();
            renderer.material.color = (pos.x + pos.y) % 2 == 0 ? SafeColor.Instance.GetColorByType(TypeColor.white)  : SafeColor.Instance.GetColorByType(TypeColor.black);
        }
    }
    
   

}
