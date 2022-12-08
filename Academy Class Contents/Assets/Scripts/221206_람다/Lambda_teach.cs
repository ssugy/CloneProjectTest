using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ���ٽ� -> ���� �޼����� Ī��
 * => �����ڸ� ���
 * => ������ �Ű������� �ǹ�, �������� ���̳� �� �ڵ���� �ǹ�
 * ���ٽĿ����� �Ű������� ������ �� ���������� ������� �ʾƵ� �ȴ�.
 * 
 * [�� ���ٿ����� �������� �����Ѵ�]
 * �Ű������� ���� �Ķ���
 * ()=>x*x; (�Ķ���)
 * 
 * �Ű������� �ִ� �Ķ���
 * (x)=>x*x;
 * 
 * �Ű������� ���� �� ����
 * ()=>{ };
 * 
 * �Ű������� �ִ� �� ����
 * (x)=>{ };
 * 
 * -----------------
 * �븮��(delegate)
 * C���� �Լ� �����Ϳ� ����
 * �Լ��� �븮 ������ ���� �� �� �ֵ��� ����
 * �Լ��� �����Ͽ� ���
 * �����ϴ� �Լ��� �븮���� ���ǿ� ���ϰ�, �Ű������� Ÿ�԰� ������ �¾ƾ� �Ѵ�.
 * �븮�ڴ� �Լ��� ���� �� �� �ִ� �ڷ���.
 */
public delegate void DoSample();
public delegate int DoIntReturn();
public class Lambda_teach : MonoBehaviour
{
    float elapsed;
    DoSample doSomething;
    DoIntReturn doIntReturn;
    DoSample doBlink;
    // ���̺꿡�� �����ϴ� delegate�� Action
    // Action<�Ű������� �ڷ���>
    /*
        Action�̶�?
    ���̺귯������ �����ϴ� delegate
    �Ѱ��� �Ű������� ��ȯ������ ���� delegate
    Action<�Ű������� �ڷ���>
     */
    Action<float> act2 = null;
    public void ActionFunction(float _data) { Debug.Log("�׼��Լ� : " + _data); }

    /*
    Func��?
    ���̺귯������ �����ϴ� delegate
    �ݵ�� ��ȯ������ �����Ѵ�.
    Func<T, TREsult> : T�� �Ű�����, TResult�� ��ȯ����
    Func<TResult> : �̷��� �ϳ��� �ۼ��ϸ� �Ű������� �����ϰ�, ��ȯ���ĸ� ����
     */
    Func<bool> funcB = null; // ������ bool�� �Լ�
    Func<Do, bool> funcC = null;
    // ����
    // funcB�� ���� �� �� �ִ� �Լ��� �����Ͻÿ�
    public bool AssignFuncB() { return true; }
    //public bool AssignFuncC(Do _do) { return true; }    // �̷��Դ� �ȵ�. ������ ��ƴٰ� ����
    public bool AssignFuncC(DoSample _do) { return true; }

    // ���� 1�� ��������Ʈ ü��
    DoSample doChain;

    private void Start()
    {
        doSomething = Something;

        // ��������Ʈ�� ���ٽ� �ֱ�
        doSomething += () => { Debug.Log("���ٽ� �۾�"); };
        doSomething();  // ����

        doIntReturn = () => 20 * 20;    // int���� ����� ��ȯ�ϱ� ������ �븮�� ��ȯ������ int�̾�� �Ѵ�.
        Debug.Log("�� ��Ʈ���� : " + doIntReturn());

        DoAction(() =>
        {
            Debug.Log("DoAction �Լ��� �Ű������� ����");
        });

        DoAction(Something);

        // Action���
        act2 = ActionFunction;
        act2(100f);

        // Func���
        funcB = () => false;

        // 1������
        doChain += AFunc;
        doChain += BFunc;
        doChain();

        // 3������
        elapsed = 1;
        doBlink = AFunc;
    }

    public void Something() { Debug.Log("�۾�1��"); }

    /**
     * �Լ��� �Ű������� ����(�Ϲ��Լ��� �Ű������� ��������Ʈ�� ���� -> �Լ��� �Ű������� �Լ��� ��)
     */
    void DoAction(DoSample _do)
    {
        if (_do != null)
        {
            _do();
        }
    }

    void AFunc()
    {
        Debug.Log("A");
        doBlink = BFunc;
    }
    void BFunc()
    {
        Debug.Log("B");
        doBlink = AFunc;
    }

    private void Update()
    {
        // ���� 3�� - ������Ʈ���� �ѹ� ����
        if (doChain != null)
        {
            doChain();
            doChain = null;
        }

        // ���� 4�� - 1�ʸ��� �ѹ��� A�Լ��� B�Լ��� �����Ƽ� ȣ���ϴ� ���α׷� �ڵ� �ۼ�(��������Ʈ �̿�)
        // 1) ������Ʈ������ ����ϴ� ���
        // 2) invoke�Լ� �̿�
        // 3) �ڷ�ƾ ��������Ʈ ����
        // ������ ���̵���ε�.
        elapsed += Time.deltaTime;
        if (elapsed >= 1)
        {
            doBlink();
            elapsed -= 1;
        }
    }
}
