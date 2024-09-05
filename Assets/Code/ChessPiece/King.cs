
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    
    public override List<Vector2Int> GetListPosCanMove()
    {
        List<Vector2Int> posResult = new();
        Vector2Int[] offsets = new Vector2Int[]
        {
            new Vector2Int(posInBoard.x, posInBoard.y+1),   
            new Vector2Int(posInBoard.x, posInBoard.y-1), 
            new Vector2Int(posInBoard.x+1, posInBoard.y),   
            new Vector2Int(posInBoard.x-1, posInBoard.y),  
            new Vector2Int(posInBoard.x+1, posInBoard.y+1),   
            new Vector2Int(posInBoard.x-1, posInBoard.y+1),  
            new Vector2Int(posInBoard.x-1, posInBoard.y-1), 
            new Vector2Int(posInBoard.x+1, posInBoard.y-1)  
        };

        foreach (Vector2Int offset in offsets)
        {
            if(offset.x < 0 || offset.y < 0 || offset.x >=8 || offset.y >=8) continue;
            Vector2Int posAdd = new Vector2Int(offset.x, offset.y);
            if (board.pointPices[posAdd.x, posAdd.y].IsHasChess)
            {
                ChessPiece chessInPos = board.pointPices[posAdd.x, posAdd.y].GetChessInTile();
                if (chessInPos.color == color)
                {
                    continue;
                }
            }
            posResult.Add(posAdd);
        }

        // ChessPieceManager chessPieceManager = ChessPieceManager.Instance;
        // HashSet<Vector2Int> enemyMoves = new HashSet<Vector2Int>();
        //
        // foreach (ChessPiece chessPiece in chessPieceManager.ChessPieces)
        // {
        //     if (chessPiece.color != this.color)
        //     {
        //         enemyMoves.UnionWith(chessPiece.GetListPosCanMove());
        //     }
        // }
        //
        // posResult.RemoveAll(pos => enemyMoves.Contains(pos));
        
        return posResult;
    }
    
    
    
    
    
    
    
    public override ChessPieceType GetTypeOfChessPiece()
    {
        return ChessPieceType.King;
    }
}
