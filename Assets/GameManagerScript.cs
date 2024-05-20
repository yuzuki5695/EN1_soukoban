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
    



    //�N���X�̒� ���\�b�g�̊O�ɏ���
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
      //      debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }
    //�N���X�̒� ���\�b�g�̊O�ɏ���
    //�Ԃ�l�̌^�ɒ���
    int GetplayerIndex()
    {
        for (int y = 0; y < field.Length; y++)
        {
            for (int x = 0; x < field.Length; x++)
            {

                if (field[y, x] == null) { continue }
                if (field[y, x].tag == "Player") { return new Vector2Int(x, y); }
            }

        }
       return  new Vector2Int(-1, -1);
    }


    bool Movenumber(string tag,Vector2Int moveFrom,Vector2Int moveTo)
    {
        //�c�����̔z��O�Q�Ƃ����Ă��Ȃ���
        if (moveTo.y < 0 || moveTo.y>= map.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= map.GetLength(1)) { return false; }


        //Box�^�O���v���Ă�����ċN����
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            Vector2Int vector = moveTo - moveFrom;
            bool succes = MoveNumder(tag, moveTo, moveTo + velocity);
            if (!succes) { return false; }    
        }
        //   if (map[moveTo] == 2)
        //   {
        //       int velocity = moveTo - moveFrom;
        //      bool success = MoveNumder                            
        //         (2, moveTo, moveTo + velocity);
        //      if (!success) { return false; }
        //  }

        //    map[moveTo] = number;
        //   map[moveFrom] = 0;
        return true;
    }


    //�N���X�̒� ���\�b�g�̊O�ɏ���
    //�Ԃ�l�̌^�ɒ���
    bool MoveNumder(int numder,int moveFrom,int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length) {  return false; }

        //�����Ȃ��������ɏ����A���^�[������A�������^�[��

      //  if (map[moveTo] == 2)
        {
            //�ǂ̕����ֈړ����Z�o
            int velocity = moveTo - moveFrom;
            //�ړ������̍ċN
            bool success = MoveNumder(2,moveTo,moveTo + velocity);
            //�����ړ����s������A�v���C���[�̈ړ������s
            if (!success) { return false; }
        }
        //�v���C���[�E���ւ�炸�̈ړ�����
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
        


        //�m�F����
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
                    //����������
                    //GameObject instance
                    field[y,x] = Instantiate(
                  PlayerPrefab, //�R�s�[��������I�u�W�F�N�g
                  new Vector3(
                  x- map.GetLength(1) / 2, 
                  -y + map.GetLength(0) / 2, 0),//�I�u�W�F�N�g�̈ʒu
                  Quaternion.identity//�I�u�W�F�N�g�̌���
                  );
                }
            }
           // debugText += "\n";//���s
        }
      //  Debug.Log(debugText);


    }

    // Update is called once per frame
    void Update()
    {
      //  if (Input.GetKeyDown(KeyCode.RightArrow))
      //  {
      //      int PlayerIndex = GetplayerIndex();

        //    MoveNumder(1, PlayerIndex, PlayerIndex + 1);
         //   PrintArray();
      //  }

     ///   if (Input.GetKeyDown(KeyCode.LeftArrow))
     //   {
     //       int PlayerIndex = GetplayerIndex();

      //      MoveNumder(1, PlayerIndex, PlayerIndex - 1);
      //      PrintArray();
      //  }
    }

}
