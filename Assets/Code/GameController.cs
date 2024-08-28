
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private ChessPiece _currentPieceSelect;
  
    [SerializeField] private ChessBoard _chessBoard;
    private Camera _currentCamera;


    private void Awake()
    {
        _currentCamera = Camera.main;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
         
            RaycastHit info;
            Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);

            if (_currentPieceSelect == null)
            {
                if(Physics.Raycast(ray,out info,100,LayerMask.GetMask("Piece")))
                {
                    _currentPieceSelect = info.transform.gameObject.GetComponent<ChessPiece>();
                    _currentPieceSelect.ShowPossibleMoves();
                    _chessBoard.HighlightValidMoves( _currentPieceSelect.color,_currentPieceSelect.ListCanMove);
                }
            }
            else
            {
                if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile")))
                {
                        Tile tile = info.transform.gameObject.GetComponent<Tile>();
                        if (_currentPieceSelect.CanMoveTo(tile.GetPosInBoard()))
                        {
                            tile.IsHasChess = true;
                            _currentPieceSelect.MoveTo(tile.GetPosInBoard());
                            _currentPieceSelect = null;
                            _chessBoard.ResetColorBoard();
                        }
                }
                
            }
           

           
        }
       
    }
    
    
    
    
}
