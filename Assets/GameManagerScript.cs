using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;


public class GameManagerScript : MonoBehaviour
{
    public GameObject PlayerPrefab;
    int[,] map;
    GameObject[,] field;
    GameObject obj;




    ////クラスの中 メソットの外に書く
    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //  //      debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}

    //クラスの中 メソットの外に書く
    //返り値の型に注意
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
               

              if (field[y, x] == null) { return continue; }


               if (field[y, x].tag == "Player") 
               {
                    return new Vector2Int(x, y); 
               }
            }

        }
       return  new Vector2Int(-1, -1);
    }


    bool Movenumber(Vector2Int moveFrom,Vector2Int moveTo)
    {
        //縦横軸の配列外参照をしていないか
        if (moveTo.y < 0 || moveTo.y>= map.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= map.GetLength(1)) { return false; }

        //   if (map[moveTo] == 2)
        //   {
        //       int velocity = moveTo - moveFrom;
        //      bool success = MoveNumder                            
        //         (2, moveTo, moveTo + velocity);
        //      if (!success) { return false; }
        //  }

        //Boxタグを思っていたら再起処理
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            Vector2Int vector = moveTo - moveFrom;
            bool succes = MoveNumder(tag, moveTo, moveTo + velocity);
            if (!succes) { return false; }
        }

        field[moveTo.y, moveTo.x].transform.position =
            new Vector3(x, map.GetLength(0) - y, 0);


        field[moveTo.y,moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }


    //クラスの中 メソットの外に書く
    //返り値の型に注意
    bool MoveNumber(int numder,int moveFrom,int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length) {  return false; }

        //動けない条件を先に書き、リターンする、早期リターン

      //  if (map[moveTo] == 2)
        {
            //どの方向へ移動か算出
            int velocity = moveTo - moveFrom;
            //移動処理の再起
            bool success = MoveNumber(2,moveTo,moveTo + velocity);
            //箱が移動失敗したら、プレイヤーの移動も失敗
            if (!success) { return false; }
        }
        //プレイヤー・箱関わらずの移動処理
      //  map[moveTo] = numder;
       // map[moveFrom] = 0;
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

        field = new GameObject[

            map.GetLength(0),
            map.GetLength(1)
          ];
        


        //確認する
         //GameObject instantiate = Instantiate(
          //  PlayerPrefab,
           // new Vector3(0, 0, 0),
            //Quaternion.identity
        //);

       // map = new int[,]{

       // }


        //  string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                //  debugText += map[y, x].ToString() + ",";
                if (map[y, x] == 1)
                {
                    //書き換える
                    //GameObject instance
                    field[y,x] = Instantiate(
                  PlayerPrefab, //コピーする既存オブジェクト
                  new Vector3(
                  x, map.GetLength(0) - y,0),//オブジェクトの位置
                  Quaternion.identity//オブジェクトの向き
                  );
                }
            }
           // debugText += "\n";//改行
        }
      //  Debug.Log(debugText);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2Int PlayerIndex = GetPlayerIndex();

            MoveNumber(PlayerIndex, PlayerIndex + new Vector2Int(1,0));
           // PrintArray();
        }

       if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int PlayerIndex = GetPlayerIndex();

            MoveNumber(PlayerIndex, PlayerIndex + new Vector2Int(1, 0));
           // PrintArray();
        }
    }

}
