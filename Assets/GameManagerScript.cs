using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
    // 追加
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;// 変更。二次元配列で宣言
    GameObject[,] field;// ゲーム管理用の配列

    // クラスの中、メソッドの外に書くことに注意
    // 返り値の型の注意
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y,x] == null) { continue; }
                // nullならcontinueされる
                // この行に来る場合は、nullでないことが確定.
                // タグ確認
                if (field[y,x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
            }          
        }
        return new Vector2Int(-1, -1);
    }
    // クラスの中、メソッドの外に書くことに注意
    // 返り値の型の注意
    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        // 移動先が範囲外なら移動不可
        if (moveTo.y < 0 || moveTo.y >= map.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= map.GetLength(2)) { return false; }

        if (field[moveTo.y,moveTo.x] != null && field[moveTo.y,moveTo.x].tag == "Box")
        {
            Vector2Int veloctity = moveTo - moveFrom;
            bool success = MoveNumber(moveTo, moveTo + veloctity);
            if (!success) { return false; }
        }  
        // プレイヤー ・ 箱関わらずの移動処理       
        field[moveFrom.y, moveFrom.x].transform.position =
            new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }

    void Start()
    {
        map = new int[,] {
        { 0,0,0,0,0},
        { 0,0,1,0,0},
        { 0,0,0,0,0},
        };
        field = new GameObject
        [
            map.GetLength(0),
            map.GetLength(1)
        ];

        string debugText = "";
        // 変更. 二重for分で二次元配列の情報を出力
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                    debugText += map[y, x].ToString() + ", ";
                }
                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(
                        boxPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                    debugText += map[y, x].ToString() + ", ";
                }
            }
            debugText += "\n"; //改行
        }
        Debug.Log(debugText);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // メソッド化した処理を使用
            Vector2Int PlayerIndex = GetPlayerIndex();
            // 移動処理を関数化
            MoveNumber(
                PlayerIndex,
                PlayerIndex + new Vector2Int(1,0));            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // メソッド化した処理を使用
            Vector2Int PlayerIndex = GetPlayerIndex();
            // 移動処理を関数化
            MoveNumber(
                PlayerIndex,
                PlayerIndex + new Vector2Int(1, 0));
        }
    }
}
