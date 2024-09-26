using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessPieceManager : Singleton<ChessPieceManager>
{
    private List<ChessPiece> _chessPieces = new();
    [SerializeField] private DataChessPieceManager dataChessPieceManager;
    [SerializeField] private ChessBoard _chessBoard;
    public List<ChessPiece> ChessPieces => _chessPieces;

    private void Start()
    {
        InitChessPiece();
    }

    private void InitChessPiece()
    {
         //SetupPieces(ChessPieceColor.Black, 0, 1);
        // SetupPieces(ChessPieceColor.White, 7, 6);
        
        SpawnPiece( new Vector2Int(4, 0), ChessPieceColor.Black,ChessPieceType.King);
        SpawnPiece( new Vector2Int(4, 7), ChessPieceColor.White,ChessPieceType.King);
        
        
       // SpawnPiece( new Vector2Int(5, 5), ChessPieceColor.Black,ChessPieceType.Pawn);
        SpawnPiece( new Vector2Int(0, 0),  ChessPieceColor.Black,ChessPieceType.Rook);  
        SpawnPiece( new Vector2Int(7, 7), ChessPieceColor.White,ChessPieceType.Rook);
        
        SpawnPiece( new Vector2Int(3, 0),  ChessPieceColor.Black,ChessPieceType.Queen);
        SpawnPiece( new Vector2Int(3, 7),  ChessPieceColor.White,ChessPieceType.Queen);
      
    }

    public ChessPiece GetChessByType(ChessPieceType type , ChessPieceColor color)
    {
        return _chessPieces.FirstOrDefault(chess => chess.color == color && chess.GetPieceType() == type);
    }

    public void SetupPieces(ChessPieceColor color , int backRow , int pawnRown)
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
        Transform gospawn = dataChessPieceManager.GetPiecePrefab(color, type);
        Transform chessSpawn = Instantiate(gospawn);
        ChessPiece piece = chessSpawn.GetComponent<ChessPiece>();
        _chessPieces.Add(piece);
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

    public void DeSpawnPiece(ChessPiece chessPiece)
    {
        _chessPieces.Remove(chessPiece);
        Destroy(chessPiece.gameObject);
    }

    public List<ChessPiece> GetChessEnemy(ChessPieceColor colorEnemy)
    {
        List<ChessPiece> result = new();
        foreach (var chessPiece in _chessPieces)
        {
            if(chessPiece.color == colorEnemy) continue;
            result.Add(chessPiece);
        }
        return result;
    }
    
    
    public List<ChessPiece> GetChessByColor(ChessPieceColor color)
    {
        List<ChessPiece> result = new();
        foreach (var chessPiece in _chessPieces)
        {
            if(chessPiece.color != color) continue;
            result.Add(chessPiece);
        }
        return result;
    }
    
}
