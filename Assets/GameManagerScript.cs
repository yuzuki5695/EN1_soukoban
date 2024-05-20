using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    //配列の宣言
    int[] map;

     void Start()
    {
        map = new int[] {0,0,0,1,0,0,0,0,0};
        string debugText = "";

        //デバックログの出力
        //Debug.Log("Hello world");//削除
        for(int i = 0; i < map.Length; i++)
        {
            //文字列を結合
            debugText += map[i].ToString() + ",";

        }
        //文字列を出力
        Debug.Log(debugText);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightParen))
        {
            int PlayerIndex = -1;
            //要素はmap.Lengthで取得
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    PlayerIndex = i;
                    break;
                }
            }

            if (PlayerIndex < map.Length - 1)
            {

                map[PlayerIndex + 1] = 1;
                map[PlayerIndex] = 0;

            }

            string debugText = "";
            for (int i = 0; i < map.Length; i++)
            {
                debugText += map[i].ToString() + ", ";
            }
            Debug.Log(debugText);
        }
    }
}
