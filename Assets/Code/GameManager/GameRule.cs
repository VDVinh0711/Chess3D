using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRule
{
    public bool CheckLose(ChessPieceColor enemyColor)
    {
        ChessPieceManager chessPieceManager = ChessPieceManager.Instance;
        ChessPiece kingEnemy = chessPieceManager.ChessPieces.FirstOrDefault(chess =>
            chess.color == enemyColor && chess.GetTypeOfChessPiece() == ChessPieceType.King);
        if (kingEnemy.GetListPosCanMove().Count != 0) return false;
        return true;
    }

    public bool IsCheckKingEnemy(ChessPieceColor enemyColor , out ChessPiece[] ChessPiceceProtect)
    {
        List<ChessPiece> chessProtect = new();
        ChessPieceManager chessPieceManager = ChessPieceManager.Instance;
        ChessPiece kingEnemy = chessPieceManager.ChessPieces.FirstOrDefault(chess =>
            chess.color == enemyColor && chess.GetTypeOfChessPiece() == ChessPieceType.King);
        foreach (ChessPiece chessPiece in chessPieceManager.ChessPieces)
        {
            if (chessPiece.color != enemyColor)
            {
                if(chessPiece.GetTypeOfChessPiece() == ChessPieceType.King) continue;
                foreach (var pos in chessPiece.GetListPosCanMove())
                {
                    if (pos == kingEnemy.PosInBoard)
                    {
                        chessProtect.Add(chessPiece);
                        break;
                    }
                 
                }
               
            }
        }
        ChessPiceceProtect = chessProtect.ToArray();
        return chessProtect.Count !=0 ;
    }


    public bool IscanEat(ChessPiece current, ChessPiece enemy)
    {
        if (current.GetListPosCanMove().Contains(enemy.PosInBoard))
        {
            return true;
        }

        return false;
    }
}
