using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Std_Lamda : MonoBehaviour
{
    public delegate int Do(int _a);
    Do doSomeThing;

    public delegate void Func();
    Func showSomething;

    public delegate void Func2(int _a);
    Func2 doSomeThingParameter;
    private void Start()
    {
        #region ��������Ʈ �⺻ �����
        //�Ķ���Ͱ� ���� ��� ����
        showSomething = () => Debug.Log("");
        showSomething = () => { Debug.Log(""); };
        //showSomething = () => { Debug.Log("") };    // ����
        showSomething = () => { Debug.Log("test"); System.Console.WriteLine("123"); };

        // �Ķ����, ����Ÿ���� �ִ� ��� ����
        doSomeThing = (x) => x * x;
        doSomeThing = (x) => { return x * x; };
        //doSomeThing = (x) => { x * x; }   // ����
        //doSomeThing = (x) => { x * x; };  // ����
        doSomeThing = (x) => { System.Console.WriteLine(""); return x * x; };

        // �Ķ���͸� �ִ� ��� ����
        doSomeThingParameter = (x) => Debug.Log(x);
        //doSomeThingParameter = (x) => x * x;    // ����
        doSomeThingParameter = (x) => { Debug.Log(x); };

        int result = doSomeThing(2);
        Debug.Log(result);

        showSomething();
        #endregion

        #region ��������Ʈ �Լ� �Ķ���ͷ� ���
        // �̷��� �Ķ���͸� ����, ��������Ʈ�� ����ϴ� ��쵵 ����. (�Ʒ��� ���� ����� ����.)
        Test((x) => {
            return x * x + 100;
        });

        Test(doSomeThing = (x) =>
        {
            return x * x + 100;
        });

        Test(doSomeThing = (x) =>
        {
            return x * x + 100;
        });

        Test(doSomeThing, 2);   //�̷��� ����ؼ� ��������Ʈ�� �Ķ���͸� �߰� �� �� �ִ�.
        #endregion

        #region ����Ʈ ����
        List<int> list = new List<int>();
        for (int i = 0; i < 10; i++)
            list.Add(i);

        var tmp = list.Find((o) => o == 99);
        Debug.Log(tmp); // ���ϴ� ������ ��ã���� null�� �ƴ϶� 0�� �����Ѵ�.
                        // �׷��� ���ϴ� �����Ͱ� 0�ΰ��, �̰� ��ã�Ƽ� 0����, 0�� ã�Ƽ� 0������ �� �� ����.
        int? tmp2 = list.Find((a) => a == 99);  // nullüũ�ص� ����� 0 �����ϴ�.
        if (tmp2.HasValue)
            Debug.Log(tmp2);    //���� ������ ��µǰ� 0�� ����
        else
            Debug.Log("�˻��ϴ� �����Ͱ� �������� �ʽ��ϴ�.");  //����� ��µ��� �ʴ´�.

        //int tmp3 = list.Find((a) => { return a.Equals(99) ? a : 10) };  // �̷������� �ȵ�. ����
        #endregion

        Todo = null;
    }

    //��������Ʈ�� �Ķ���ͷ� �޴°��
    public void Test(Do _doSomething)
    {
        int result = _doSomething(2);
        Debug.Log($"Test = {result}");
    }
    
    //��������Ʈ, ��������Ʈ�� �Ķ���͸� �޴°��
    public void Test(Do _doSomething, int _a)
    {
        int result = _doSomething(_a);
        Debug.Log($"Test = {result}");
    }
    
    // �̷������� list�˻��� ���� �Լ��� ���� ��� �� �� �ִ�.(�̷����ϸ� ã�°��� ������ null��ȯ �Ѵ�.)
    public int? FindData(List<int> _list, int _findData)
    {
        foreach (int item in _list)
        {
            if (item.Equals(_findData))
            {
                return _findData;
            }
        }
        return null;
    }

    #region �����ذ�1
    //update�Լ����� ���ǹ��� �ѹ��� ����ϰ� Ư�� �̺�Ʈ���� �Լ� ȣ���� �� �� �ִ� ���α׷� �ڵ带 �ۼ��Ͻÿ�.
    //�� �Լ� ȣ���� 1���� �Ѵ�.
    Func Todo;
    
    public void SetEvent(int eventIndex, Func _toDo)
    {
        Debug.Log($"{eventIndex} �̺�Ʈ �߻�");
        Todo = _toDo;
        Todo += _toDo;  // �ι�ȣ���ϰ� �ϰ� ���� ��
    }

    public void SetEvent(int eventIndex, Func[] _toDo)
    {
        Debug.Log($"{eventIndex} �̺�Ʈ �߻�");
        foreach (Func item in _toDo)
        {
            Todo += item;   // �̷������� �迭�� ������, �迭�� ����� ȣ������� ���ϴ´�� ���� �� �ִ�.
        }
    }

    int cnt = 0;
    public void EventAction()
    {
        Debug.Log($"{++cnt} EventAction");
    }
    
    // 3������ �޾Ƽ� �����ϱ�.
    private void StressTest(int eventIndex, Func _toDo)
    {
        Debug.Log($"{eventIndex} �̺�Ʈ �߻�");
        for (int i = 0; i < 30000; i++)
            Todo += _toDo;
    }

    private void Update()
    {
        //���콺 ���� ��ư ������ �� �����ϱ�
        if (Input.GetMouseButtonDown(0))
        {
            SetEvent(2, EventAction);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SetReturnEvent();   // ���ϰ� �ִ� �Լ����� üũ�� ���� �ڵ�
        }

        if (Todo != null)
        {
            Todo();
            Todo = null;
        }

        if (returnSomething != null)
        {
            //int a = returnSomething(5);
            //Debug.Log($"{a} �������ϰ�");    // �̰� ������ �Լ��� ���ϰ��� ������ �ȴ�. �׷��� �߰��� ���ϵǴ� ���� ���������� �����ؼ� ����ؾߵȴ�.

            Delegate[] arrFunc = returnSomething.GetInvocationList();
            foreach (Do item in arrFunc)
            {
                Debug.Log("�����ؼ� ����");
                item(5);
            }
            returnSomething = null;
        }
    }
    #endregion
    Do returnSomething = null;
    private void SetReturnEvent()
    {
        returnSomething += Sum;
        returnSomething += Multiple;
    }

    private int Sum(int a) 
    {
        Debug.Log(a + a);
        return a + a;
    }
    private int Multiple(int a)
    {
        Debug.Log(a * a);
        return a * a;
    }
}
