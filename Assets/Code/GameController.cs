using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ChessPiece _currentPieceSelect;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ChessBoard _chessBoard;
    private Camera _currentCamera;
    private GameRule _gameRule;

    private ChessPiece[] _chessPiecesProtect;

    private void Awake()
    {
        _currentCamera = Camera.main;
        _gameRule = new GameRule();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100, LayerMask.GetMask("Piece")))
        {
            HandlePieceClick(hitInfo);
        }
        else if (Physics.Raycast(ray, out hitInfo, 100, LayerMask.GetMask("Tile")))
        {
            HandleTileClick(hitInfo);
        }
    }

    private void HandlePieceClick(RaycastHit hitInfo)
    {
        _chessBoard.ResetColorBoard();
        ChessPiece clickedPiece = hitInfo.transform.GetComponent<ChessPiece>();

        if (_playerController.CurrentTurn.isCheck)
        {
            bool isExits =_chessPiecesProtect.FirstOrDefault(c => c.GetTypeChessPiece() == clickedPiece.GetTypeChessPiece()) != null;
            if (!isExits)  return;
        }
        if (clickedPiece.color == _playerController.CurrentTurn.ColorChess)
        {
            SelectPiece(clickedPiece);
        }
        else if (_currentPieceSelect != null && _gameRule.IscanEat(_currentPieceSelect, clickedPiece))
        {
            EatPiece(clickedPiece);
        }
    }

    private void SelectPiece(ChessPiece piece)
    {
        _currentPieceSelect = piece;
        _chessBoard.HighlightValidMoves(_currentPieceSelect.color, _currentPieceSelect.GetListPosCanMove());
    }

    private void EatPiece(ChessPiece targetPiece)
    {
        _currentPieceSelect.MoveTo(targetPiece.PosInBoard);
        ChessPieceManager.Instance.DeSpawnPiece(targetPiece);
        EndMoveChessPiece();
        EndClick();
    }

    private void HandleTileClick(RaycastHit hitInfo)
    {
        if (_currentPieceSelect == null) return;

        Tile clickedTile = hitInfo.transform.GetComponent<Tile>();
        if (_currentPieceSelect.CanMoveTo(clickedTile.GetPosInBoard()))
        {
            _currentPieceSelect.MoveTo(clickedTile.GetPosInBoard());
            EndMoveChessPiece();
            EndClick();
        }
    }

    private void EndMoveChessPiece()
    {
        ChessPieceColor enemyColor = _currentPieceSelect.color == ChessPieceColor.White
            ? ChessPieceColor.Black
            : ChessPieceColor.White;

        _playerController.SwitchTurn();
        _playerController.CurrentTurn.isCheck = _gameRule.IsCheckKingEnemy(_playerController.CurrentTurn.ColorChess, out _chessPiecesProtect);
       
        foreach (var chessPiece in _chessPiecesProtect)
        {
            Debug.Log(chessPiece.GetTypeChessPiece());
        }
 
    }

    private void EndClick()
    {
        _currentPieceSelect = null;
        _chessBoard.ResetColorBoard();
    }
}