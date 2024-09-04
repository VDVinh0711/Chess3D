
using UnityEngine;

public class Tile : MonoBehaviour
{

    private int _x;
    private int _y;
    private bool _isHasChess = false;
    
    public bool IsHasChess
    {
        set => this._isHasChess = value;
        get => _isHasChess;
    }
    public Tile SetPosition(int x, int y)
    {
        this._x = x;
        this._y = y;
        return this;
    }
    public Vector2Int GetPosInBoard()
    {
        return new Vector2Int(_x, _y);
    }

    public ChessPiece GetChessInTile()
    {
        if (!_isHasChess) return null;
        return this.gameObject.GetComponentInChildren<ChessPiece>();
    }

    public void DisplayValidMoves(ChessPieceColor colorChessMove)
    {
        ChessPiece chessInTile = transform.GetComponentInChildren<ChessPiece>();
        Debug.Log(this.transform.childCount);
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
         if (chessInTile != null && colorChessMove != chessInTile.color)
         {
          //  Show color khác
           
            renderer.material.color = SafeColor.Instance.GetColorByType(TypeColor.hlenemyy);
         }
         else
         {
           // Show color direct
            renderer.material.color = SafeColor.Instance.GetColorByType(TypeColor.heightlight);
        }
        
    }
    
    
    
    
}
