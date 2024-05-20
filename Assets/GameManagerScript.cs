using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
   // �ǉ�

    int[,] map;// �ύX�B�񎟌��z��Ő錾

    //�N���X�̒��A���\�b�h�̊O�ɏ������Ƃɒ���
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ", ";
        }
        Debug.Log(debugText);  
    }

    // �N���X�̒��A���\�b�h�̊O�ɏ������Ƃɒ���
    // �Ԃ�l�̌^�̒���
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
    // �N���X�̒��A���\�b�h�̊O�ɏ������Ƃɒ���
    // �Ԃ�l�̌^�̒���
    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        // �ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo < 0 || moveTo >= map.Length) { return false; }
        // �ړ����2(��)��������
        if (map[moveTo] == 2)
        {
            // �ǂ̕����ֈړ����邩���Z�o
            int velocity = moveTo - moveFrom;
            // �v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�
            // �ړ������̃��\�b�h���ĂсA�������ċN�B
            // �ړ��s��bool�ŋL�^
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            // �����ړ����s������A�v���C���[�̈ړ������s
            if (!success) { return false; }
        }
        // �v���C���[ �E ���ւ�炸�̈ړ�����       
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
        // �ύX. ��dfor���œ񎟌��z��̏����o��
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ", ";
            }
            debugText += "\n"; //���s
        }
        Debug.Log(debugText);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightParen))
        {
            // ���\�b�h�������������g�p
            int PlayerIndex = GetPlayerIndex();
            // �ړ��������֐���
            MoveNumber(1, PlayerIndex, PlayerIndex + 1);
            PrintArray();
            
        }
    }
}
