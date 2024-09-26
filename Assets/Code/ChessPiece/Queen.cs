using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    private static readonly Vector2Int[] AllDirections = new Vector2Int[]
    {
        new(0, 1), new(0, -1), new(1, 0), new(-1, 0),  // Straight
        new(1, 1), new(1, -1), new(-1, 1), new(-1, -1) // Diagonal
    };

    public override List<Vector2Int> GetAvailableMoves()
    {
        return GetMovesInDirections(AllDirections);
    }

    public override ChessPieceType GetPieceType()
    {
        return ChessPieceType.Queen;
    }

    public override List<Vector2Int> GetPathToEnemyKing(ChessPieceColor enemyColor , Vector2Int enemyKingPos)
    {
        return null;
    }

    public override bool CanCheckEnemyKing(Vector2Int enemyKingPos)
    {
        return GetAvailableMoves().Contains(enemyKingPos);
    }

    public override List<Vector2Int> GetAttackPositions(ChessPieceColor enemyColor)
    {
        return GetMovesInDirections(AllDirections, true);
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