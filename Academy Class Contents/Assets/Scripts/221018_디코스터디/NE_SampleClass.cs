using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE_SampleClass : MonoBehaviour
{
    // �̸�, ����
    string name = "����";
    public int age = 10;
    public static int age2 = 10;

    //������?
    public NE_SampleClass()
    {
        //������
        Debug.Log("������ ����");
    }

    public NE_SampleClass(int a)
    {
        age = a;
        //������
        Debug.Log("������ ����");
    }

    /**
     * �����ε� : �̸��� ������, �Ķ������ ������ �ٸ��ų�  Ÿ���� �ٸ��� ��� ����
     * ���߾� - �������̵� : ���� Ŭ�������ִ� �Լ��� ���� Ŭ�������� ������ �ϴ� ��. ���� Ŭ���������� ���� �ʿ��Ѱ���? � Ű����?
     */


    public void ShowNE()
    {
        Debug.Log("ShowNE���� " + age);
    }
    
    public static void ShowNE2()
    {
        Debug.Log("ShowNE���� " + age2);
        Debug.Log("ShowNE����");
    }
}
