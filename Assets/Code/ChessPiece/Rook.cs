

using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector2Int> GetListPosCanMove()
    {

        List<Vector2Int> posResult = new();
        Vector2Int[] directions = new Vector2Int[]
        {
            new Vector2Int(0, 1),   // Forward
            new Vector2Int(0, -1),  // Back
            new Vector2Int(1, 0),   // Right
            new Vector2Int(-1, 0)   // Left
        };

        foreach (var direction in directions)
        {
            for (int i = 1; i < 8; i++)
            {
                Vector2Int posAdd = new Vector2Int(posInBoard.x + i * direction.x, posInBoard.y + i * direction.y);
            
                if (!IsValidPosition(posAdd)) break;

                if (board.pointPices[posAdd.x, posAdd.y].IsHasChess)
                {
                    ChessPiece chessInPos = board.pointPices[posAdd.x, posAdd.y].GetChessInTile();
                    if (chessInPos.color != color)
                    {
                        posResult.Add(posAdd);
                    }
                    break;
                }
            
                posResult.Add(posAdd);
            }
        }
       return posResult;
    }
    
    private bool IsValidPosition(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
    }
    public override ChessPieceType GetTypeOfChessPiece()
    {
        return ChessPieceType.Rook;
    }
}
