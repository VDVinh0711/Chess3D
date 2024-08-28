using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ChessPieceColor
{
    None,
    White,
    Black
}

public enum ChessPieceType
{
    None,
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
}

[Serializable]
public class ChessPieceData
{
    public Transform prefab;
    public ChessPieceType type;
}

[Serializable]
public class ColoredChessPieceSet
{
    public ChessPieceColor color;
    public List<ChessPieceData> pieces = new List<ChessPieceData>();

    public Transform GetPiecePrefab(ChessPieceType pieceType)
    {
        return pieces.FirstOrDefault(piece => piece.type == pieceType)?.prefab;
    }
}

public class DataChessPieceManager : MonoBehaviour
{
    [SerializeField] private List<ColoredChessPieceSet> chessSets = new List<ColoredChessPieceSet>();

    public Transform GetPiecePrefab(ChessPieceColor color, ChessPieceType pieceType)
    {
        var colorSet = chessSets.FirstOrDefault(set => set.color == color);
        return colorSet?.GetPiecePrefab(pieceType);
    }
}