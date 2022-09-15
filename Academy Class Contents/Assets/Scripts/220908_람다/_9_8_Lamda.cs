using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ��ȯ������ �����̰� �Ű������� ������ ��������Ʈ ����
public delegate int DoN();
public delegate void DoV();

public class _9_8_Lamda : MonoBehaviour
{
    public delegate int Do(int _a); // Do��� �̸��� �ٸ����� ������̶� �ӽ÷� Ŭ���� ������ ������.
    Do doSomething;
    DoN doSomethingN;
    DoV doSomethingV;
    // �����ذ�
    DoV ToDo;
    void Start()
    {
        // ���ٽ��� �̿��Ͽ� �Լ��� �����ϰ� ����
        doSomething = (x) => x * x;
        doSomethingN = () => 2 * 2;
        doSomethingV = () => Debug.Log("123");
        // doSomething�� ���ٽ����� ������ �Լ��� ������ ����
        int result = doSomething(4);
        Debug.Log("��� = " + result);
        doSomething = (x) => 
        {
            int result = x * x + 100;
            return result;
        };
        result = doSomething(2);
        Debug.Log("��� = " + result);
        Test(doSomething, 2);

        List<int> list = new List<int>();
        for(int i = 0; i < 10; i++)
            list.Add(i);

        //int? tmp = list.Find(o => o == 99);
        int? findData = FindData(list, 99);
        if (findData.HasValue)
        {
            Debug.Log(findData);
        }
        else
        {
            Debug.Log("�˻��ϴ� �����Ͱ� �������� �ʽ��ϴ�.");
        }
        ToDo = null;
    }
    public int? FindData(List<int> _list, int _findData)
    {
        foreach(int one in _list)
        {
            if (one.Equals(_findData))
                return one;      
        }
        return null;
    }
    public void Test(Do _doSomething, int _arg)
    {
        int result = _doSomething(_arg);
        Debug.Log("Test = " + result);
    }

    // Ư�� �̺�Ʈ�� �߻������� ȣ���� �Լ�

    /*
     * �����ذ�
    1. Update�Լ����� ���ǹ��� �ѹ��� ����Ͽ� Ư�� �̺�Ʈ���� �Լ� ȣ���� �Ҽ� �ִ� 
        ���α׷� �ڵ带 �ۼ��Ͻÿ�. ��, �Լ� ȣ���� 1���� �Ѵ�.
     */
    // 2�� �̺�Ʈ �߻��� ȣ���Լ�
    public void EventAction()
    {
        Debug.Log("EventAction");
    }
    public void StressTest(int _eventIndex, DoV _toDo)
    {
        Debug.Log(_eventIndex + " ���̺�Ʈ�߻�");
        for (int i = 0; i < 20000; i++)
        {
            ToDo += _toDo;
        }
    }
    public void SetEvent(int _eventIndex, DoV _toDo)
    {
        Debug.Log(_eventIndex + " ���̺�Ʈ�߻�");
        ToDo = _toDo;
        ToDo += _toDo;
    }
    public void SetEvent(int _eventIndex, DoV [] _toDos)
    {
        Debug.Log(_eventIndex + " ���̺�Ʈ�߻�");
        foreach(DoV one in _toDos)
        {
            ToDo += one;
        }
    }
    void Update()
    {
        // �����ذ� : �׽�Ʈ
        // ���콺 �̺�Ʈ�� �߻������� 2�� �̺�Ʈ�� ����
        if(Input.GetMouseButtonDown(0))
        {
            //SetEvent(2, EventAction);
            StressTest(2, EventAction);
        }
        if(ToDo != null)
        {
            // ��ȯ������ �����ϴ� �Լ��ϰ�� ������ �Լ��� �迭�� �������� ȣ���Ѵ�.
            //Delegate [] arrFunc = ToDo.GetInvocationList();
            //foreach(Delegate one in arrFunc)
            //{
            //    DoV f = (DoV)one;
            //    f();
            //}
            //ToDo -= ToDo;

            // ��ȯ������ �������� �ʴ� �Լ��� ���
            ToDo();
            Debug.Log("EndToDo");
            ToDo -= ToDo;
        }
    }
}
