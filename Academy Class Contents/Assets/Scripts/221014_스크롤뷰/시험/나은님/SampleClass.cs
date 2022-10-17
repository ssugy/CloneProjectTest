using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SampleClass : MonoBehaviour
{
    //��� 1 : ���� �����ϱ�
    //public NE_Class2 c1;
    //public NE_Class2 c2;
    //public NE_Class2 c3;

    // ��� 2 : �迭�� �����ϱ�
    //public NE_Class2[] c = new NE_Class2[3];   // 0 1 2 => ũ��

    // ��� 3 : ����Ʈ�� �����ϱ�
    public List<NE_Class2> ne;


    private void Start()
    {
        // ��� 1 - �ʱ�ȭ
        //Debug.Log(c1.num1); //10
        //Debug.Log(c2.num1); //20

        // ��� 2 - �ʱ�ȭ
        //c[0].num1 = 10;
        //c[1].num1 = 10;
        //c[2].num1 = 10;

        //Debug.Log(c[0].num1);    // 10
        //Debug.Log(c[1].num1);    // 10
        //Debug.Log(c[2].num1);    // 10

        // ��� 3 - ����Ʈ
        // 1) ����Ʈ�� ����� ���ʿ� �޸� �Ҵ��� �ؾߵ˴ϴ�.
        // 2) ����Ʈ�� ADD�մϴ�.
        // 3) ����Ʈ����[�ε���]�� �̿��ؼ� ������ �����մϴ�.
        
        // ������ int�� ���� 5���� 1 2 3 4 5�̷��� ���� ���ִ� ����Ʈ�� �����ϰڴ�.
        //List<int> c = new List<int>(); //  ��� ���� �� �ִ�.(�� ����Ʈ��) => �̰� �޸� �Ҵ��ϸ� �����ڳ׿�? -> �������� �߰� �� �� ���� �޸𸮸� �߰��� �Ҵ��ϴ� ���.
        //c.Add(1);   //�ε����� 0�� ��
        //c.Add(2);
        //c.Add(3);
        //c.Add(4);   // �ε����� 3�� ��
        //c.Add(5);
        //Debug.Log(c[3]); //4 -����

        //NE_Class2 ne2 = new NE_Class2();
        //ne.Add(ne2);    // Ŭ���� �߰�

        ne[0].ShowNum(10);
        ne[1].ShowNum(10);
        ne[2].ShowNum(10);
        
    }

    public int[] test;  // �ν����� â���� ũ�⸦ ���Ѵ� = �޸𸮸� �˾Ƽ� �Ҵ����ش�. �׷��� new�� �ʿ����

    private void Update()
    {
        // ��ư ������ �� 10 20 30
        if (Input.GetMouseButtonDown(0))
        {
            //c2.num1 = 30;
            //Debug.Log(c1.num1); //10

            //c[0].num1 = 10;
            //c[1].num1 = 20;
            //c[2].num1 = 30;  

            ne[0].num1 = 10;
            ne[1].num1 = 20;
            ne[2].num1 = 30;
        }
    }
}
