using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
  
   

    public override List<Vector2Int> GetListPosCanMove()
    {

        List<Vector2Int> posResult = new();
        Vector2Int[] offsets = new Vector2Int[]
        {
            new Vector2Int(posInBoard.x - 1, posInBoard.y+2),   
            new Vector2Int(posInBoard.x + 1, posInBoard.y+2), 
            new Vector2Int(posInBoard.x+2, posInBoard.y +1),   
            new Vector2Int(posInBoard.x+2, posInBoard.y-1),  
            new Vector2Int(posInBoard.x+1, posInBoard.y-2),   
            new Vector2Int(posInBoard.x-1, posInBoard.y-2),  
            new Vector2Int(posInBoard.x-2, posInBoard.y-1), 
            new Vector2Int(posInBoard.x-2, posInBoard.y+1)  
        };
        
        
        foreach (Vector2Int offset in offsets)
        {
            if(offset.x < 0 || offset.y < 0) continue;
            Vector2Int posAdd = new Vector2Int(offset.x, offset.y);
            if(posAdd.x <0 || posAdd.x >=8 || posAdd.y <0 || posAdd.y >=8 ) continue; 
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


      
        return posResult;
    }

    public override ChessPieceType GetTypeChessPiece()
    {
        return ChessPieceType.Knight;
    }
}
