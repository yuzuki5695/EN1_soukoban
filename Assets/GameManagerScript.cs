using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{

    int[,] map;


   //�N���X�̒� ���\�b�g�̊O�ɏ���
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }
    //�N���X�̒� ���\�b�g�̊O�ɏ���
    //�Ԃ�l�̌^�ɒ���
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
    //�N���X�̒� ���\�b�g�̊O�ɏ���
    //�Ԃ�l�̌^�ɒ���
    bool MoveNumder(int numder,int moveFrom,int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length) {  return false; }

        //�����Ȃ��������ɏ����A���^�[������A�������^�[��

        if (map[moveTo] == 2)
        {
            //�ǂ̕����ֈړ����Z�o
            int velocity = moveTo - moveFrom;
            //�ړ������̍ċN
            bool success = MoveNumder(2,moveTo,moveTo + velocity);
            //�����ړ����s������A�v���C���[�̈ړ������s
            if (!success) { return false; }
        }
        //�v���C���[�E���ւ�炸�̈ړ�����
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
