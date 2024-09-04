using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    public override void ShowPossibleMoves(ChessPieceColor color)
    {
       //Move strange

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


       
      // Hướng lên
       for (int i = 1; i < 8 - posInBoard.x ; i++)
       {
           Vector2Int posAdd = new Vector2Int(posInBoard.x + i, posInBoard.y + i);
           if(posAdd.x <0 || posAdd.x >=8 || posAdd.y <0 || posAdd.y >=8 ) continue; 
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
       
       //Chéo Xuống
       for (int i = 1; i < 8 - posInBoard.x ; i++)
       {
        
           Vector2Int posAdd = new Vector2Int(posInBoard.x + i, posInBoard.y - i);
           if(posAdd.x <0 || posAdd.x >=8 || posAdd.y <0 || posAdd.y >=8 ) continue; 
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
       
       // CHéo lên bên trái
       for (int i = 0; i <  posInBoard.x ; i++)
       {
           Vector2Int posAdd = new Vector2Int(posInBoard.x - (i +1), posInBoard.y + i + 1);
           if(posAdd.x <0 || posAdd.x >=8 || posAdd.y <0 || posAdd.y >=8 ) continue; 
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
       
       //Chéo Xuống bên trái
       for (int i = 0; i <  posInBoard.x ; i++)
       {
        
           Vector2Int posAdd = new Vector2Int(posInBoard.x - i -1 , posInBoard.y - i - 1);
           if(posAdd.x <0 || posAdd.x >=8 || posAdd.y <0 || posAdd.y >=8 ) continue; 
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
