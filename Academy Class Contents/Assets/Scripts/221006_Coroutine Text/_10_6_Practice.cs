using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_6_Practice : MonoBehaviour
{
    /*
     1. Update �Լ��� ������ ������ �ϴ� �ڷ�ƾ �Լ��� �ۼ��ϼ���.
        �ڷ�ƾ�Լ������� �ݺ����� ����Ѵ�.
        Update�� ������� �ʰ� �ڷ�ƾ �Լ��� ����ϰڴٴ� �ǹ�
     */
    public bool isUpdate { get; set; }
    float coElapsed;
    int coCount;
    float elapsed;
    int count;
    void Start()
    {
        coElapsed = 0f;
        elapsed = 0f;
        count = 0;
        coCount = 0;
        isUpdate = true;
        //StartCoroutine(CoroutineUpdate());
    }
    IEnumerator CoroutineUpdate()
    {
        while (isUpdate)
        {
            // do to
            // 1�ʵ��ȿ� ��� ȣ��
            coElapsed += Time.deltaTime;
            coCount++;
            if (coElapsed >= 1f)
            {
                coElapsed -= 1f;
                Debug.Log("�ڷ�ƾ = " + coCount);
                coCount = 0;
            }
            yield return null;
        }
        yield break;
    }
    void Update()
    {
        elapsed += Time.deltaTime;
        count++;
        // 1�ʵ��ȿ� ��� ȣ��
        if (elapsed >= 1f)
        {
            elapsed -= 1f;
            Debug.Log("�̺�Ʈ�Լ� = " + count);
            count = 0;
        }
    }
}
