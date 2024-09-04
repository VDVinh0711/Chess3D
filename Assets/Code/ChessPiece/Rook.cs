

using UnityEngine;

public class Rook : ChessPiece
{
    public override void ShowPossibleMoves(ChessPieceColor color)
    {
          //Move ForWard
       for (int i = posInBoard.y + 1; i < 8; i++)
       {
           Vector2Int posAdd = new Vector2Int(posInBoard.x, i);
           if (board.pointPices[posAdd.x, posAdd.y].IsHasChess)
           {
               ChessPiece chessInPos = board.pointPices[posAdd.x, posAdd.y].GetChessInTile();
               if (chessInPos.color == color)
               {
                   break;
               }
               ListCanMove.Add(posAdd);
               break;
           }
           ListCanMove.Add(posAdd);
       }
       
       //Move back
       for (int i = posInBoard.y-1; i >= 0; i--)
       {
           Vector2Int posAdd = new Vector2Int(posInBoard.x, i);
           if (board.pointPices[posAdd.x, posAdd.y].IsHasChess)
           {
               ChessPiece chessInPos = board.pointPices[posAdd.x, posAdd.y].GetChessInTile();
               if (chessInPos.color == color)
               {
                   break;
               }
               ListCanMove.Add(posAdd);
               break;
           }
           ListCanMove.Add(posAdd);
       }
       
       //Move Right
       for (int i = posInBoard.x+1; i < 8; i++)
       {
           Vector2Int posAdd = new Vector2Int(i, posInBoard.y);
           if (board.pointPices[posAdd.x, posAdd.y].IsHasChess)
           {
               ChessPiece chessInPos = board.pointPices[posAdd.x, posAdd.y].GetChessInTile();
               if (chessInPos.color == color)
               {
                   break;
               }
               ListCanMove.Add(posAdd);
               break;
           }
           ListCanMove.Add(posAdd);
       
       }
       
       //Move Left
       for (int i = posInBoard.x-1; i >= 0; i--)
       {
           Vector2Int posAdd = new Vector2Int(i, posInBoard.y);
           if (board.pointPices[posAdd.x, posAdd.y].IsHasChess)
           {
               ChessPiece chessInPos = board.pointPices[posAdd.x, posAdd.y].GetChessInTile();
               if (chessInPos.color == color)
               {
                   break;
               }
               ListCanMove.Add(posAdd);
               break;
           }
           ListCanMove.Add(posAdd);
       }
    }
}
