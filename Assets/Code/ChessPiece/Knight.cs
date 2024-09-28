using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    private static readonly Vector2Int[] KnightMoves = new Vector2Int[]
    {
        new(-1, 2), new(1, 2),
        new(2, 1), new(2, -1),
        new(1, -2), new(-1, -2),
        new(-2, -1), new(-2, 1)
    };

    public override List<Vector2Int> GetAvailableMoves()
    {
        return GetValidMoves(false);
    }

    public override ChessPieceType GetPieceType()
    {
        return ChessPieceType.Knight;
    }
    
    public override bool CanCheckEnemyKing(Vector2Int enemyKingPos)
    {
        return GetAvailableMoves().Contains(enemyKingPos);
    }

    public override List<Vector2Int> GetAttackPositions(ChessPieceColor enemyColor)
    {
        return GetValidMoves(true);
    }

    private List<Vector2Int> GetValidMoves(bool ignoreOccupied)
    {
        List<Vector2Int> validMoves = new();

        foreach (Vector2Int move in KnightMoves)
        {
            Vector2Int newPos = posInBoard + move;

            if (IsValidPosition(newPos))
            {
                if (ignoreOccupied || !board.pointPices[newPos.x, newPos.y].IsHasChess ||
                    board.pointPices[newPos.x, newPos.y].GetChessInTile().color != color)
                {
                    validMoves.Add(newPos);
                }
            }
        }

        return validMoves;
    }

    private bool IsValidPosition(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
    }
}