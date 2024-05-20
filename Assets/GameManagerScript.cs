using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
   // 追加

    int[,] map;// 変更。二次元配列で宣言

    //クラスの中、メソッドの外に書くことに注意
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ", ";
        }
        Debug.Log(debugText);  
    }

    // クラスの中、メソッドの外に書くことに注意
    // 返り値の型の注意
    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return 1;
            } 
        }
        return -1;
    }
    // クラスの中、メソッドの外に書くことに注意
    // 返り値の型の注意
    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        // 移動先が範囲外なら移動不可
        if (moveTo < 0 || moveTo >= map.Length) { return false; }
        // 移動先に2(箱)がいたら
        if (map[moveTo] == 2)
        {
            // どの方向へ移動するかを算出
            int velocity = moveTo - moveFrom;
            // プレイヤーの移動先から、さらに先に2(箱)を移動
            // 移動処理のメソッドを呼び、処理を再起。
            // 移動可不可をboolで記録
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            // 箱が移動失敗したら、プレイヤーの移動も失敗
            if (!success) { return false; }
        }
        // プレイヤー ・ 箱関わらずの移動処理       
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    void Start()
    {
        map = new int[,] {
        { 0,0,0,0,0},
        { 0,0,1,0,0},
        { 0,0,0,0,0},
        };
        string debugText = "";
        // 変更. 二重for分で二次元配列の情報を出力
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ", ";
            }
            debugText += "\n"; //改行
        }
        Debug.Log(debugText);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightParen))
        {
            // メソッド化した処理を使用
            int PlayerIndex = GetPlayerIndex();
            // 移動処理を関数化
            MoveNumber(1, PlayerIndex, PlayerIndex + 1);
            PrintArray();
            
        }
    }
}
