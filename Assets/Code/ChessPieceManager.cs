using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ChessPieceManager : Singleton<ChessPieceManager>
{
    private List<ChessPiece> _activePieces = new();
    [SerializeField] private DataChessPieceManager _chessPieceDataManager;
    [SerializeField] private ChessBoard _chessBoard;
    public List<ChessPiece> ActivePieces => _activePieces;

    private void Start()
    {
        InitializeChessBoard();
    }

    private void InitializeChessBoard()
    {
        // SetupInitialPosition(ChessPieceColor.Black, 0, 1);
        // SetupInitialPosition(ChessPieceColor.White, 7, 6);
        
        SpawnPiece( new Vector2Int(4, 0), ChessPieceColor.Black,ChessPieceType.King);
        SpawnPiece( new Vector2Int(4, 7), ChessPieceColor.White,ChessPieceType.King);
        
        
       // SpawnPiece( new Vector2Int(5, 5), ChessPieceColor.Black,ChessPieceType.Pawn);
        SpawnPiece( new Vector2Int(0, 0),  ChessPieceColor.Black,ChessPieceType.Rook);  
        SpawnPiece( new Vector2Int(7, 7), ChessPieceColor.White,ChessPieceType.Rook);
        
        SpawnPiece( new Vector2Int(3, 0),  ChessPieceColor.Black,ChessPieceType.Queen);
        SpawnPiece( new Vector2Int(3, 7),  ChessPieceColor.White,ChessPieceType.Queen);
      
    }

    public ChessPiece GetPieceByTypeAndColor(ChessPieceType type , ChessPieceColor color)
    {
        return _activePieces.FirstOrDefault(chess => chess.color == color && chess.GetPieceType() == type);
    }

    public void SetupInitialPosition(ChessPieceColor color , int backRow , int pawnRown)
    {
        for (int i = 0; i < 8; i++)
        {
            SpawnPiece( new Vector2Int(i, pawnRown), color,ChessPieceType.Pawn);
        }
        
        SpawnPiece( new Vector2Int(0, backRow), color,ChessPieceType.Rook);
        SpawnPiece( new Vector2Int(7, backRow), color,ChessPieceType.Rook);

        // Đặt mã
        SpawnPiece( new Vector2Int(1, backRow), color , ChessPieceType.Knight);
        SpawnPiece( new Vector2Int(6, backRow), color, ChessPieceType.Knight);

        // Đặt tượng
        SpawnPiece( new Vector2Int(2, backRow), color,ChessPieceType.Bishop);
        SpawnPiece( new Vector2Int(5, backRow), color , ChessPieceType.Bishop);

        // Đặt hậu
        SpawnPiece( new Vector2Int(3, backRow), color,ChessPieceType.Queen);

        // Đặt vua
       // SpawnPiece( new Vector2Int(4, backRow), color,ChessPieceType.King);
        SpawnPiece( new Vector2Int(4, backRow), color,ChessPieceType.King);
    }
    
    
    public void SpawnPiece( Vector2Int posInBoard, ChessPieceColor color , ChessPieceType type)
    {
        Transform gospawn = _chessPieceDataManager.GetPiecePrefab(color, type);
        Transform chessSpawn = Instantiate(gospawn);
        ChessPiece piece = chessSpawn.GetComponent<ChessPiece>();
        _activePieces.Add(piece);
        if (piece != null)
        {
            piece.Initialize(_chessBoard, posInBoard,color );
            _chessBoard.pointPices[posInBoard.x, posInBoard.y].IsHasChess = true;
        }
        else
        {
            Debug.LogError("Piece prefab does not have a ChessPiece component!");
        }
    }

    public void RemovePiece(ChessPiece chessPiece)
    {
        _activePieces.Remove(chessPiece);
        Destroy(chessPiece.gameObject);
    }
    public List<ChessPiece> GetOpponentPieces(ChessPieceColor playerColor)
    {
        return _activePieces.Where(piece => piece.color != playerColor).ToList();
    }
    
    public List<ChessPiece> GetPlayerPieces(ChessPieceColor playerColor)
    {
        return _activePieces.Where(piece => piece.color == playerColor).ToList();
    }
    public ChessPiece GetOpponentPieceByType(ChessPieceColor playerColor, ChessPieceType type)
    {
        ChessPieceColor opponentColor = playerColor == ChessPieceColor.Black ? ChessPieceColor.White : ChessPieceColor.Black;
        return GetPieceByTypeAndColor(type, opponentColor);
    }
}
