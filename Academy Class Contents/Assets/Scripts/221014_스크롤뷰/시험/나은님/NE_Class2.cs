using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE_Class2 : MonoBehaviour
{
    public int num1;

    // �Լ��� �ϳ� ������̿���. -> �� �Լ��� �����Ű��, num1�� ���� ����ϴ� ��.
    public void ShowNum(int data)
    {
        num1 = data;
        Debug.Log("�����Լ� ����" + num1);
    }
    
    public void ShowNum()
    {
        Debug.Log("�����Լ� ����" + num1);
    }
}
