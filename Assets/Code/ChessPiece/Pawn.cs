using UnityEngine;

public class Pawn : ChessPiece
{
    private bool _isMoveFirst = false;
    
    public override void MoveTo(Vector2Int targetPosition)
    {
        base.MoveTo(targetPosition);
        _isMoveFirst = true;
        ListCanMove.Clear();
    }
    public override void ShowPossibleMoves()
    {
        if (!_isMoveFirst)
        {
                Vector2Int pointMove2 = new Vector2Int(posInBoard.x, posInBoard.y + 2);
                ListCanMove.Add(pointMove2);
        }
        Vector2Int pointMove = new Vector2Int(posInBoard.x, posInBoard.y + 1);
        ListCanMove.Add(pointMove);
      
    }
}