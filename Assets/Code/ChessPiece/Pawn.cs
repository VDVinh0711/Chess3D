using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    private bool _isMoveFirst = false;
    
    public override void MoveTo(Vector2Int targetPosition)
    {
        base.MoveTo(targetPosition);
        Debug.Log(targetPosition.y);
        if (targetPosition.y == 0 && this.color == ChessPieceColor.White || targetPosition.y == 7 && this.color == ChessPieceColor.Black)
        {
            ChessPieceManager.Instance.SpawnPiece(targetPosition,this.color,ChessPieceType.Queen);
            ChessPieceManager.Instance.DeSpawnPiece(this);
        }
        _isMoveFirst = true;
        
    }

    public override List<Vector2Int> GetListPosCanMove()
    {
        List<Vector2Int> posResult = new();
        List<Vector2Int> offsets = new();
        if (this.color == ChessPieceColor.Black)
        {
            offsets.Add(new Vector2Int(posInBoard.x + 1, posInBoard.y +1));
            offsets.Add(new Vector2Int(posInBoard.x - 1, posInBoard.y +1));
            
            if (!_isMoveFirst)
            {
                offsets.Add(new Vector2Int(posInBoard.x, posInBoard.y + 2));
            }
            offsets.Add(new Vector2Int(posInBoard.x, posInBoard.y + 1));
           
        }
        else
        {
            offsets.Add(new Vector2Int(posInBoard.x - 1, posInBoard.y -1));
            offsets.Add(new Vector2Int(posInBoard.x + 1, posInBoard.y -1));
            if (!_isMoveFirst)
            {
                offsets.Add(new Vector2Int(posInBoard.x, posInBoard.y - 2));
            }
            offsets.Add(new Vector2Int(posInBoard.x, posInBoard.y - 1));
        }
        
       
        foreach (Vector2Int offset in offsets)
        {
            if(offset.x <0 || offset.x >=8 || offset.y <0 || offset.y >=8 ) continue; 
            if (offset.x != this.posInBoard.x)
            {
                if (board.pointPices[offset.x, offset.y].IsHasChess)
                {
                    ChessPiece chessInPos = board.pointPices[offset.x, offset.y].GetChessInTile();
                    if (chessInPos.color != color)
                    {
                        posResult.Add(offset);
                    }
                }
            }
            else
            {
                posResult.Add(offset);
            }
           
        }

        return posResult;
    }

    public override ChessPieceType GetTypeOfChessPiece()
    {
        return ChessPieceType.Pawn;
    }
}