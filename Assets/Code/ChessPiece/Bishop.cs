

using UnityEngine;

public class Bishop : ChessPiece
{
   

    public override void ShowPossibleMoves(ChessPieceColor color)
    {
              
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
