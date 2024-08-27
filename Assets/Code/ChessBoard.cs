using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    private Camera _currentCamera;
    public Tile[,] pointPices = new Tile[8, 8];
    [SerializeField] private GameObject _squarePrefab;
    [SerializeField] private Transform _holder;
    private Vector2Int _currentHover;
    void OnEnable()
    {
        CreateChessBoard();
    }

    private void Update()
    {
        if (!_currentCamera)
        {
            _currentCamera = Camera.current;
            return;
        }

        RaycastHit info;
        Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out info,100,LayerMask.GetMask("Tile")))
        {
            
        }
    }

    private Vector2Int LooKupIndex(GameObject goHitInfo)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (pointPices[x, y] == goHitInfo)
                {
                    return new Vector2Int(x, y);
                }
            }
        }

        return -Vector2Int.one;
    }
    void CreateChessBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject square = Instantiate(_squarePrefab,_holder);
                square.transform.position = new Vector3(x, 0, y);
                square.transform.localScale = new Vector3(0.1f, 1, 0.1f);
                pointPices[x, y] = square.GetComponent<Tile>().SetPosition( (int)  square.transform.position.x,(int) square.transform.position.z);
                Renderer renderer = square.GetComponent<Renderer>();
                renderer.material.color = (x + y) % 2 == 0 ? Color.white : Color.black;
            }
        }
    }
    
   

}
