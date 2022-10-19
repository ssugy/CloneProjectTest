using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

class Animal
{
    public int age;
    const int test = 10;

    //decimal a = 100000000000000000000000000000000000000000000000;


    virtual public void Speak()
    {
        Debug.Log("�θ�-����ũ");
    }
}

class Dog : Animal
{
    override public void Speak()
    {

    }
}

public class NE_Basic : MonoBehaviour, IPointerDownHandler
{
    void Start()
    {
        //IF_Remind();
        //CodeBlock(1, 1.0f);
        Inherit();
    }


    #region �⺻�Լ� ����
    // �Լ� ����
    private void IF_Remind()
    {
        /**
         * ���̽� 1�� : num = 12, num2 = 3
         * ���̽� 2�� : num = 8, num2 = 7
         * ���̽� 3�� : num = 8, num2 = 3
         * ���̽� 4�� : num = 12, num2 = 7
         */

        int num = 10;
        int num2 = 5;

        if (num++ > 10 && --num2 < 5)   // ����/���� ������
        {
            // ���� : num�� 10���� ũ�� num2 5���� ������� (and)
            Debug.Log($"�� {num} || {num2}");    //10 4
        }
        else
        {
            // ���� : num�� 10���� �۰ų� ����, num2�� 5���� ũ�� (and? or?)
            Debug.Log($"�Ʒ� {num} || {num2}");   // 11 4????? 11�� 5�ε���?
        }
    }
    #endregion

    #region ��ǲ �ʵ� ����
    //-------------------------------- ��ǲ �ʵ� ��ư����
    public void ShowName(string str)
    {
        Debug.Log("�ǿ��� �Դϴ�." + str);
    }

    public void OnValueChanged(string str)
    {
        Debug.Log("OnValueChanged" + str);
    }

    public void OnEndEdit()
    {
        Debug.Log("OnEndEdit");
    }

    public void OnSelect()
    {
        Debug.Log("OnSelect");
    }

    public void DeSelect()
    {
        Debug.Log("�� DeSelect");
    }


    public void OnValueChanged2(float str)
    {
        Debug.Log("OnValueChanged" + str);
    }
    #endregion

    #region �ڵ��
    //-- �ڵ��
    int num1 = 1;
    /// <summary>
    /// �Լ��� ���� �����߰�
    /// </summary>
    /// <param name="a">a�Ķ���� ����</param>
    /// <param name="b">b�Ķ���� ����</param>
    public void CodeBlock(int a, float b)
    {
        NE_SampleClass ns = new NE_SampleClass(20);
        ns.ShowNE();    // 20
        NE_SampleClass ns2 = new NE_SampleClass();
        ns2.ShowNE();   //10

        ns.age = 15;
        ns2.ShowNE();   // 10
        ns.ShowNE();    // 15

        NE_SampleClass.age2 = 12;
        NE_SampleClass.ShowNE2();   // 12
    }

    private void OnEnable()
    {
        Debug.Log("���ο��̺�");
    }

    private void OnDisable()
    {
        int num = 0;
        {
            
        }
    }
    #endregion

    public void Inherit()
    {
        Animal ani2 = new Dog();

        Animal ani = new Animal();
        ani.Speak();

        Dog dog = new Dog();
        dog.age = 15;
    }


    public void OnPointerDown(PointerEventData eventData)   // �θ�
    {
        OnImgClick(eventData);
    }

    public void OnImgClick(BaseEventData _data) //�ڽ�
    {
        //PointerEventData Data = _data as PointerEventData;
        PointerEventData Data;
        if (_data is PointerEventData)  // is : �ٲܼ��ֳ�? t / f
        {
            Data = _data as PointerEventData;
        }
        else
        {
            Data = null;
        }

        Debug.Log("OnImgClick Ŭ���� ��ġ = " + Data.position);
    }


    public void OnImgClick2(int _data) //�ڽ�
    {
        //(��ĭ)Data = _data as (��ĭ);
        //Debug.Log("OnImgClick Ŭ���� ��ġ = " + Data.position);

        List<string> list = new List<string>();
        foreach (var item in list)
        {
            Debug.Log(item);
        }

        var test = 10.0d;
        //bool test2 = 1;
    }

}
