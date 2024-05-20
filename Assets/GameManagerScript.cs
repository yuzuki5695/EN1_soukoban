using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    //�z��̐錾
    int[] map;

     void Start()
    {
        map = new int[] {0,0,0,1,0,0,0,0,0};
        string debugText = "";

        //�f�o�b�N���O�̏o��
        //Debug.Log("Hello world");//�폜
        for(int i = 0; i < map.Length; i++)
        {
            //�����������
            debugText += map[i].ToString() + ",";

        }
        //��������o��
        Debug.Log(debugText);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightParen))
        {
            int PlayerIndex = -1;
            //�v�f��map.Length�Ŏ擾
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
