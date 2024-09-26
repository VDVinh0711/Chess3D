using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRule
{
    public bool CheckLose(ChessPieceColor enemyColor)
    {
        // _curentturn is check and King don't have point to move and dont have any chess can protect
        ChessPieceManager chessPieceManager = ChessPieceManager.Instance;
        ChessPiece kingEnemy = chessPieceManager.ChessPieces.FirstOrDefault(chess =>
            chess.color == enemyColor && chess.GetPieceType() == ChessPieceType.King);
        if (kingEnemy.GetAvailableMoves().Count != 0) return false;
        return true;
    }

    public bool IsCheckKingEnemy( ChessPieceColor color )
    {
        ChessPieceColor colorenemy = color == ChessPieceColor.Black ? ChessPieceColor.White : ChessPieceColor.Black; 
        ChessPieceManager chessPieceManager = ChessPieceManager.Instance;
        Vector2Int posKingEnemy = chessPieceManager.GetChessByType(ChessPieceType.King, colorenemy).PosInBoard;
        foreach (var chessPiece  in chessPieceManager.GetChessByColor(color))
        {
            if (chessPiece.CanCheckEnemyKing(posKingEnemy))
            {
                return true;
            }
        }
        return false;
    }


    public bool IscanEat(ChessPiece current, ChessPiece enemy) =>
        current.GetAvailableMoves().Contains(enemy.PosInBoard);

    
}
