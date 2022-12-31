using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    bool isReadyShow;   // �ѹ��� ����ϱ� ���� ������ ����
    Character player;
    private void Awake()
    {
        isReadyShow = true;
    }

    void Start()
    {
        player = new Character();
        Debug.Log("�ν��Ͻ��� �����Ǿ����ϴ�.");
        player.Attack(5);
        player.Defence(5);
        player.LevelUP(10);
    }

    void Update()
    {
        if (isReadyShow && Time.time >= 3)
        {
            isReadyShow = false;
            Debug.Log("�̸���  = " + player.NAME + "�Դϴ�.");
            Debug.Log("���̴�  = " + player.AGE + "�Դϴ�.");
            Debug.Log("������  = " + player.SEX + "�Դϴ�.");
            Debug.Log("������  = " + player.Level + "�Դϴ�.");
            Debug.Log("ü����  = " + player.HP + "�Դϴ�.");
        }
    }
}
