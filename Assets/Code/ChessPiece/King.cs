using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    
    
    
    public override void ShowPossibleMoves()
    {
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
            if(offset.x < 0 || offset.y < 0) continue;
            ListCanMove.Add(new Vector2Int(posInBoard.x + offset.x, posInBoard.y + offset.y));
        }
    }
}
