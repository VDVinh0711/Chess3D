
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private ChessPiece _currentPieceSelect;
    [SerializeField] private PlayerController _playerController;
    private GameRule _gameRule;
    [SerializeField] private ChessBoard _chessBoard;
    private Camera _currentCamera;


    private void Awake()
    {
        _currentCamera = Camera.main;
        _gameRule = new GameRule();
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

            Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
                // Select a piece if none is selected
                if (   _currentPieceSelect == null && Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Piece")))
                {
                    ChessPiece chessSelect = info.transform.gameObject.GetComponent<ChessPiece>();
                    _currentPieceSelect = chessSelect.color == _playerController.CurrentTurn.ColorChess ? chessSelect : null ;
                    if (_currentPieceSelect != null)
                    {
                        var validMoves = _currentPieceSelect.GetListPosCanMove();
                        _chessBoard.HighlightValidMoves(_currentPieceSelect.color, validMoves);
                    }
                }
                else if (  Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile")))
                {
                    Tile tile = info.transform.gameObject.GetComponent<Tile>();

                    if (_currentPieceSelect.CanMoveTo(tile.GetPosInBoard()))
                    {
                        _currentPieceSelect.MoveTo(tile.GetPosInBoard());
                        if (tile.IsHasChess && tile.GetChessInTile().color != _currentPieceSelect.color)
                        {
                            ChessPieceManager.Instance.DeSpawnPiece(tile.GetChessInTile());
                        }
                    }
                    EndMoveChessPiece();
                }
           
    }


    private void EndMoveChessPiece()
    {
            _chessBoard.ResetColorBoard();
            ChessPieceColor enemyColor = _currentPieceSelect.color == ChessPieceColor.White
                ? ChessPieceColor.Black
                : ChessPieceColor.White;
            _currentPieceSelect = null;
            _playerController.SwitchTurn();
            _playerController.CurrentTurn.isCheck = _gameRule.IsCheckKingEnemy(_playerController.CurrentTurn.ColorChess,
                out ChessPiece[] chessPieces);
           
            foreach (var tet in chessPieces)
            {
                Debug.Log($"{tet.GetTypeOfChessPiece()} ++ {tet.color}");
            }
            if (_gameRule.CheckLose(enemyColor))
            {
                Debug.Log("Lose");
            }
    }
   

       
    }
    
    

