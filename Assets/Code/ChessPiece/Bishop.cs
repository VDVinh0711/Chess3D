using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    private static readonly Vector2Int[] BishopDirections = new Vector2Int[]
    {
        new(1, 1),   // Up-right
        new(1, -1),  // Down-right
        new(-1, 1),  // Up-left
        new(-1, -1)  // Down-left
    };

    public override List<Vector2Int> GetAvailableMoves()
    {
        return GetMovesInDirections(BishopDirections);
    }

    public override ChessPieceType GetPieceType()
    {
        return ChessPieceType.Bishop;
    }

    public override List<Vector2Int> GetPathToEnemyKing(ChessPieceColor enemyColor , Vector2Int enemyKingPos)
    {
        ChessPiece enemyKing = ChessPieceManager.Instance.GetChessByType(ChessPieceType.King, enemyColor);
        if (enemyKing == null) return null;

        Vector2Int offset = enemyKing.PosInBoard - this.PosInBoard;
        if (Mathf.Abs(offset.x) != Mathf.Abs(offset.y)) return null;

        List<Vector2Int> path = new();
        Vector2Int direction = new(offset.x / Mathf.Abs(offset.x), offset.y / Mathf.Abs(offset.y));

        for (int i = 1; i < Mathf.Abs(offset.x); i++)
        {
            Vector2Int pos = this.PosInBoard + i * direction;
            if (this.board.pointPices[pos.x, pos.y].IsHasChess)
            {
                path.Add(pos);
            }
        }

        return path;
    }

    public override bool CanCheckEnemyKing(Vector2Int enemyKingPos)
    {
        return GetAvailableMoves().Contains(enemyKingPos);
    }

    public override List<Vector2Int> GetAttackPositions(ChessPieceColor enemyColor)
    {
        return GetMovesInDirections(BishopDirections, true);
    }

    private List<Vector2Int> GetMovesInDirections(Vector2Int[] directions, bool attackMode = false)
    {
        List<Vector2Int> availableMoves = new();

        foreach (var direction in directions)
        {
            for (int i = 1; i < 8; i++)
            {
                Vector2Int newPosition = new(posInBoard.x + i * direction.x, posInBoard.y + i * direction.y);
            
                if (!IsValidPosition(newPosition)) break;

                if (board.pointPices[newPosition.x, newPosition.y].IsHasChess)
                {
                    ChessPiece pieceAtPosition = board.pointPices[newPosition.x, newPosition.y].GetChessInTile();
                    
                    if (attackMode)
                    {
                        if (pieceAtPosition.GetPieceType() != ChessPieceType.King)
                            break;
                    }
                    else
                    {
                        if (pieceAtPosition.color != color)
                            availableMoves.Add(newPosition);
                        break;
                    }
                }
            
                availableMoves.Add(newPosition);
            }
        }

        return availableMoves;
    }
    
    private bool IsValidPosition(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
    }
}