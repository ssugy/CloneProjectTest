using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array_7_21 : MonoBehaviour
{
    // 1. ���� 6���� ������ �迭�� ����
    // - Ŭ�������� �迭������ ���������
    // - �ʱ�ȭ�� �Լ��ȿ��� 
    // 2. ���� ����
    int[] arr;
    void Start()
    {
        arr = new int[6];
        arr[0] = 1;
        arr[1] = 2;
        arr[2] = 3;
        arr[3] = 4;
        arr[4] = 5;
        arr[5] = 6;
        Debug.Log(arr[0]);
        Debug.Log(arr[1]);
    }
    void Update()
    {
        
    }
}
