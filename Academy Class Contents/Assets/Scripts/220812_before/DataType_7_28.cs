using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ü(struct)
// ��Ÿ���� ����� ���� �ڷ���
public struct Data
{
    public int data1;
    public float data2;
    public void Test()
    {
    }
}
// ����ü(enum)
// ��Ÿ���� ����� ���� �ڷ���
// �ܾ ������ ���� �����ؼ� ���
// ù��° �����ʹ� �ʱⰪ�� �������� �ʴ� �ٸ� 0���� �����ϰ� ���� ������ ���� 1�� ������ ���� ����
public enum eDATA
{
    NONE = 100,
    BLACK = 2,
    TWO
}
public class DataType_7_28 : MonoBehaviour
{
    void Start()
    {
        Debug.Log((int)eDATA.NONE);
        Debug.Log(eDATA.BLACK);
        Debug.Log(eDATA.TWO);
        // ��뿹
        int userData = 23;
        if(userData == (int)eDATA.BLACK)
        {
            //userData�� eDATA.BLACK�� ���ٸ�
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
