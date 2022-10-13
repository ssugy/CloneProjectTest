using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_6_Practice : MonoBehaviour
{
    /*
     1. Update 함수와 유사한 역할을 하는 코루틴 함수를 작성하세요.
        코루틴함수에서는 반복문을 사용한다.
        Update를 사용하지 않고 코루틴 함수를 사용하겠다는 의미
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
            // 1초동안에 몇번 호출
            coElapsed += Time.deltaTime;
            coCount++;
            if (coElapsed >= 1f)
            {
                coElapsed -= 1f;
                Debug.Log("코루틴 = " + coCount);
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
        // 1초동안에 몇번 호출
        if (elapsed >= 1f)
        {
            elapsed -= 1f;
            Debug.Log("이벤트함수 = " + count);
            count = 0;
        }
    }
}
