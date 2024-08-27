using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    
    public ChessPieceColor color;
    protected Vector2Int posInBoard;
    protected ChessBoard board;

    public virtual void Initialize(ChessBoard board, Vector2Int posInBoard, ChessPieceColor color)
    {
     
        Debug.Log(board.pointPices == null);
         this.board = board;
        this.posInBoard = posInBoard;
        this.color = color;
        Vector3 position = board.pointPices[posInBoard.x, posInBoard.y].transform.position;
        transform.position = new Vector3(position.x,0,position.z);
    }
    
    public abstract bool CanMoveTo(Vector2Int targetPosition);
    
    public virtual void MoveTo(Vector2Int targetPosition)
    {
        posInBoard = targetPosition;
        Vector3 position = board.pointPices[posInBoard.x, posInBoard.y].transform.position;
        transform.position = new Vector3(position.x, 0, position.z);
    }
}