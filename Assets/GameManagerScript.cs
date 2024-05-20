using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
    //�z��̐錾
    int[] map;

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
        map = new int[] {0,0,0,1,0,2,0,0,0};
        PrintArray();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ���\�b�h�������������g�p
            int PlayerIndex = GetPlayerIndex();
            // �ړ��������֐���
            MoveNumber(1, PlayerIndex, PlayerIndex + 1);
            PrintArray();
            
        }       
    }
}
