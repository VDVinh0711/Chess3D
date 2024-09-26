using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    private bool _hasMoved = false;

    public override void MoveTo(Vector2Int targetPosition)
    {
        base.MoveTo(targetPosition);
        
        if (ShouldPromote(targetPosition))
        {
            PromoteToQueen(targetPosition);
        }
        
        _hasMoved = true;
    }

    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> availableMoves = new();
        int direction = (color == ChessPieceColor.Black) ? 1 : -1;

        // Forward move
        AddMoveIfValid(availableMoves, new Vector2Int(posInBoard.x, posInBoard.y + direction), true);

        // Initial two-square move
        if (!_hasMoved)
        {
            AddMoveIfValid(availableMoves, new Vector2Int(posInBoard.x, posInBoard.y + 2 * direction), true);
        }

        // Diagonal captures
        AddMoveIfValid(availableMoves, new Vector2Int(posInBoard.x + 1, posInBoard.y + direction), false);
        AddMoveIfValid(availableMoves, new Vector2Int(posInBoard.x - 1, posInBoard.y + direction), false);

        return availableMoves;
    }

    public override ChessPieceType GetPieceType()
    {
        return ChessPieceType.Pawn;
    }

    public override List<Vector2Int> GetPathToEnemyKing(ChessPieceColor enemyColor , Vector2Int enemyKingPos)
    {
        return null; 
    }

    public override bool CanCheckEnemyKing(Vector2Int enemyKingPos)
    {
        return GetAttackPositions(board.pointPices[enemyKingPos.x,enemyKingPos.y].GetChessInTile().color).Contains(enemyKingPos);
    }

    public override List<Vector2Int> GetAttackPositions(ChessPieceColor enemyColor)
    {
        List<Vector2Int> attackPositions = new();
        int direction = (color == ChessPieceColor.Black) ? 1 : -1;

        AddPositionIfValid(attackPositions, new Vector2Int(posInBoard.x + 1, posInBoard.y + direction));
        AddPositionIfValid(attackPositions, new Vector2Int(posInBoard.x - 1, posInBoard.y + direction));

        return attackPositions;
    }

    private bool ShouldPromote(Vector2Int position)
    {
        return (color == ChessPieceColor.White && position.y == 0) ||
               (color == ChessPieceColor.Black && position.y == 7);
    }

    private void PromoteToQueen(Vector2Int position)
    {
        ChessPieceManager.Instance.SpawnPiece(position, color, ChessPieceType.Queen);
        ChessPieceManager.Instance.DeSpawnPiece(this);
    }

    private void AddMoveIfValid(List<Vector2Int> moves, Vector2Int newPos, bool mustBeEmpty)
    {
        if (IsValidPosition(newPos))
        {
            Tile tile = board.pointPices[newPos.x, newPos.y];
            if (mustBeEmpty && !tile.IsHasChess)
            {
                moves.Add(newPos);
            }
            else if (!mustBeEmpty && tile.IsHasChess && tile.GetChessInTile().color != color)
            {
                moves.Add(newPos);
            }
        }
    }

    private void AddPositionIfValid(List<Vector2Int> positions, Vector2Int newPos)
    {
        if (IsValidPosition(newPos))
        {
            positions.Add(newPos);
        }
    }

    private bool IsValidPosition(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
    }
}