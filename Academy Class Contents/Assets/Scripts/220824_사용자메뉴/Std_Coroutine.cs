using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
1.	���� ���� ������ ���ø�, 1�ʸ��� 10���� ü���� �ø��� ���ؼ��� � ������� �ڵ带 �ۼ��ؾ� �ɱ�?
 A.	1�ʿ� 10�̴ϱ�, update���ο� timeCnt������ �����ؼ� 1�ʸ��� 10�� ����
 B.	timeCnt���� ����ϴ� ���� ���δϱ� Time.time�� �̿��ؼ� 1�ʿ� �ѹ��� ����
 C.	(���⼭����) �ڷ�ƾ ����ؼ� 1�ʿ� �ѹ��� ������ �ֱ�.
 D.	(�߰����) InvokeRepeat�� �̿��� ���.
 E.	(�߰����) Async Await����� �̿�
 i.	��������ӿ�ũ 4.x�� �߰��� ����
 F.	(����) ������Ʈ�� ������ �޾Ƽ� ���ϴ� �������� õõ�� ���ϰ� �����.
 */
public class Std_Coroutine : MonoBehaviour
{
    Coroutine myCo;

    private void Start()
    {
        StartCoroutine("MyCoroutine");  // ���� ����
        //StartCoroutine(MyCoroutine());  // �Ϲ������� �ȵ�, stopAll�� ���� ����
        //myCo = StartCoroutine(MyCoroutine());   //�Ķ���Ͱ� �ִ� �ڷ�ƾ�� �̷������� �����ؼ� ��������ߵȴ�.
    }

    IEnumerator MyCoroutine()
    {
        int n = 0;
        while (true)
        {
            n++;
            //���� ���� �� ��
            Debug.Log("���� ����" + n);

            yield return new WaitForSeconds(2);

            //������ �� �� ��
            Debug.Log("������ �� �� ��" + n);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("���� ��ȣ");
            StopCoroutine("MyCoroutine");
            //StopCoroutine(MyCoroutine()); // �̰ɷ� �ȵ�
            //StopAllCoroutines();
            //StopCoroutine(myCo);    // �̷��� �ϸ� �Ķ�����ִ� �ڷ�ƾ�� ���� �����ϴ�.
        }
    }
}
