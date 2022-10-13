using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Coroutine2 : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;
        Debug.Log("스타트실행");
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(Test_01());
        yield return StartCoroutine(Test_02());
    }
    IEnumerator Test_01()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"{i}_1번테스트");
            yield return null;
        }
    }

    IEnumerator Test_02()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"{i}_2번테스트");
            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("update--");
    }
}
