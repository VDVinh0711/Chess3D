
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
        return gameObject.GetComponentInChildren<ChessPiece>();
    }

    public void DisplayValidMoves(ChessPieceColor colorChessMove)
    {
        ChessPiece chessInTile = transform.GetComponentInChildren<ChessPiece>();
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        renderer.material.color = chessInTile != null && colorChessMove != chessInTile.color ?
            SafeColor.Instance.GetColorByType(TypeColor.hlenemyy) :
            SafeColor.Instance.GetColorByType(TypeColor.heightlight);
    }
    
    
    
    
}
