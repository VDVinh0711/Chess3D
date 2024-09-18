using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ChessPiece : MonoBehaviour
{
    
    public ChessPieceColor color;
    protected Vector2Int posInBoard;
    protected ChessBoard board;
   
    public Vector2Int PosInBoard => posInBoard;
    

    public virtual void Initialize(ChessBoard board, Vector2Int posInBoard, ChessPieceColor color)
    {
        this.board = board;
        this.posInBoard = posInBoard;
        this.color = color;
        Transform posTile = board.pointPices[posInBoard.x, posInBoard.y].transform;
        this.transform.SetParent(posTile);
        transform.position = new Vector3(posTile.position.x,0,posTile.position.z);
        
    }

    public bool CanMoveTo(Vector2Int targetPosition)
    {
        List<Vector2Int> posCanMove = GetListPosCanMove();

        if (targetPosition == this.posInBoard) return false;
        if ( posCanMove.Contains(targetPosition))
        {
            return true;
        }
        return false;
    }
    
    public virtual void MoveTo(Vector2Int targetPosition)
    {
        board.pointPices[posInBoard.x, posInBoard.y].IsHasChess = false;
        posInBoard = targetPosition;
        Transform postile = board.pointPices[posInBoard.x, posInBoard.y].transform;
        board.pointPices[posInBoard.x, posInBoard.y].IsHasChess = true;
        this.transform.SetParent(postile);
        transform.position = new Vector3(postile.position.x, 0, postile.position.z);
    }

    public abstract List<Vector2Int> GetListPosCanMove();
    public abstract ChessPieceType GetTypeOfChessPiece();

}