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
    // �ǉ�
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;// �ύX�B�񎟌��z��Ő錾
    GameObject[,] field;// �Q�[���Ǘ��p�̔z��

    // �N���X�̒��A���\�b�h�̊O�ɏ������Ƃɒ���
    // �Ԃ�l�̌^�̒���
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y,x] == null) { continue; }
                // null�Ȃ�continue�����
                // ���̍s�ɗ���ꍇ�́Anull�łȂ����Ƃ��m��.
                // �^�O�m�F
                if (field[y,x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
            }          
        }
        return new Vector2Int(-1, -1);
    }
    // �N���X�̒��A���\�b�h�̊O�ɏ������Ƃɒ���
    // �Ԃ�l�̌^�̒���
    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        // �ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo.y < 0 || moveTo.y >= map.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= map.GetLength(2)) { return false; }

        if (field[moveTo.y,moveTo.x] != null && field[moveTo.y,moveTo.x].tag == "Box")
        {
            Vector2Int veloctity = moveTo - moveFrom;
            bool success = MoveNumber(moveTo, moveTo + veloctity);
            if (!success) { return false; }
        }  
        // �v���C���[ �E ���ւ�炸�̈ړ�����       
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
        // �ύX. ��dfor���œ񎟌��z��̏����o��
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
            debugText += "\n"; //���s
        }
        Debug.Log(debugText);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ���\�b�h�������������g�p
            Vector2Int PlayerIndex = GetPlayerIndex();
            // �ړ��������֐���
            MoveNumber(
                PlayerIndex,
                PlayerIndex + new Vector2Int(1,0));            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // ���\�b�h�������������g�p
            Vector2Int PlayerIndex = GetPlayerIndex();
            // �ړ��������֐���
            MoveNumber(
                PlayerIndex,
                PlayerIndex + new Vector2Int(1, 0));
        }
    }
}
