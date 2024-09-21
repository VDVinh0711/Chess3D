using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRule
{
    public bool CheckLose(ChessPieceColor enemyColor)
    {
        ChessPieceManager chessPieceManager = ChessPieceManager.Instance;
        ChessPiece kingEnemy = chessPieceManager.ChessPieces.FirstOrDefault(chess =>
            chess.color == enemyColor && chess.GetTypeChessPiece() == ChessPieceType.King);
        if (kingEnemy.GetListPosCanMove().Count != 0) return false;
        return true;
    }

    public bool IsCheckKingEnemy(ChessPieceColor enemyColor , out ChessPiece[] ChessPiceceProtect)
    {
       
        List<ChessPiece> chessCheckKings = new();
        ChessPieceManager chessPieceManager = ChessPieceManager.Instance;
        ChessPiece kingEnemy = chessPieceManager.ChessPieces.FirstOrDefault(chess =>
            chess.color == enemyColor && chess.GetTypeChessPiece() == ChessPieceType.King);
        foreach (ChessPiece chessPiece in chessPieceManager.ChessPieces)
        {
            if (chessPiece.color == enemyColor) continue;
            if(chessPiece.GetTypeChessPiece() == ChessPieceType.King) continue;
            foreach (var pos in chessPiece.GetListPosCanMove())
            {
                if (pos == kingEnemy.PosInBoard)
                {
                    chessCheckKings.Add(chessPiece);
                    break;
                }
            }
        }
        
        
        List<ChessPiece> chessProtect = new();
        foreach (ChessPiece chessPiece in chessPieceManager.ChessPieces)
        {
            if (chessPiece.color != enemyColor) continue;
            foreach (var pos in chessPiece.GetListPosCanMove())
            {
                bool match = false;
                foreach (var posEnemy in chessCheckKings)
                {
                    if (posEnemy.GetListPosCanMove().Contains(pos))
                    {
                        chessProtect.Add(chessPiece);
                        match = true;
                        break;
                    }
                }
                if(match) break;
            }
        }


        ChessPiceceProtect = chessProtect.ToArray();
        return chessCheckKings.Count !=0 ;
    }


    public bool IscanEat(ChessPiece current, ChessPiece enemy) =>
        current.GetListPosCanMove().Contains(enemy.PosInBoard);

    
}
