using UnityEngine;

public class Pawn : ChessPiece
{
    private bool hasMoved = false;
    
    public override bool CanMoveTo(Vector2Int targetPosition)
    {
        int direction = (color == ChessPieceColor.White) ? 1 : -1;
     
    
        
    
        return false;
    }
    
    public override void MoveTo(Vector2Int targetPosition)
    {
        base.MoveTo(targetPosition);
        hasMoved = true;
    }
}