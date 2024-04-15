using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{

    int[,] map;


   //クラスの中 メソットの外に書く
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }
    //クラスの中 メソットの外に書く
    //返り値の型に注意
    int GetplayerIndex()
    {
        for(int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }
    //クラスの中 メソットの外に書く
    //返り値の型に注意
    bool MoveNumder(int numder,int moveFrom,int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length) {  return false; }

        //動けない条件を先に書き、リターンする、早期リターン

        if (map[moveTo] == 2)
        {
            //どの方向へ移動か算出
            int velocity = moveTo - moveFrom;
            //移動処理の再起
            bool success = MoveNumder(2,moveTo,moveTo + velocity);
            //箱が移動失敗したら、プレイヤーの移動も失敗
            if (!success) { return false; }
        }
        //プレイヤー・箱関わらずの移動処理
        map[moveTo] = numder;
        map[moveFrom] = 0;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {

        map = new int[,] {
        { 0,0,0,0,0},
        { 0,0,1,0,0},
        { 0,0,0,0,0},
        };
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {

            }
        }

 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int PlayerIndex = GetplayerIndex();

            MoveNumder(1, PlayerIndex, PlayerIndex + 1);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int PlayerIndex = GetplayerIndex();

            MoveNumder(1, PlayerIndex, PlayerIndex - 1);
            PrintArray();
        }
    }



}
