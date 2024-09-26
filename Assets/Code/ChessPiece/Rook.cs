using System;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    private static readonly Vector2Int[] RookDirections = new Vector2Int[]
    {
        new(0, 1),   // Forward
        new(0, -1),  // Back
        new(1, 0),   // Right
        new(-1, 0)   // Left
    };

    public override List<Vector2Int> GetAvailableMoves()
    {
        return GetMovesInDirections(RookDirections);
    }

    public override ChessPieceType GetPieceType()
    {
        return ChessPieceType.Rook;
    }

    public override List<Vector2Int> GetPathToEnemyKing(ChessPieceColor enemyColor , Vector2Int enemyKingPos)
    {
        
        List<Vector2Int> result = new();
        Debug.Log(enemyKingPos.x != posInBoard.x || enemyKingPos.y != posInBoard.y);
        if (enemyKingPos.x != posInBoard.x && enemyKingPos.y != posInBoard.y) return null;

        if (enemyKingPos.x == posInBoard.x)
        {
            int dir = enemyKingPos.y - posInBoard.y / Mathf.Abs(enemyKingPos.y - posInBoard.y);

            int i = posInBoard.y;
            while (enemyKingPos.y  != i)
            {
                i += dir;
                Vector2Int posAdd = new Vector2Int(enemyKingPos.x, i);
                result.Add(posAdd);
            }
        }
        else
        {
            int dir = enemyKingPos.x - posInBoard.x / Mathf.Abs(enemyKingPos.x - posInBoard.x);

            int i = posInBoard.y;
            while (enemyKingPos.y  != i)
            {
                i += dir;
                Vector2Int posAdd = new Vector2Int(i,enemyKingPos.y);
                result.Add(posAdd);
            }
        }
            return result;
    }

    public override bool CanCheckEnemyKing(Vector2Int enemyKingPos)
    {
        return GetAvailableMoves().Contains(enemyKingPos);
    }

    public override List<Vector2Int> GetAttackPositions(ChessPieceColor enemyColor)
    {
        return GetMovesInDirections(RookDirections, attackMode: true);
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