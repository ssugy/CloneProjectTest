using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. �̸��� Do�� ��������Ʈ ����
delegate void Do();

public class Std_0822_Delegate : MonoBehaviour
{
    //2. Do�� ���� deFunction�� ����
    Do deFunction;

    void Start()
    {
        //3. ��������Ʈ ������ ����ϰ��� �ϴ� �Լ��� ����
        deFunction = Displaydata;
        //4. ��������Ʈ ������ ȣ��
        deFunction();
    }

    void Displaydata()
    {
        Debug.Log("DisplayData");
    }

    // Update is called once per frame
    void Update()
    {
        if (deFunction != null)
        {
            deFunction();   // �̷��� ����� �� �ִ�. �׶��׶����� �Լ��� �����ؼ� ����ϸ� �ȴ�.
        }
    }
}
