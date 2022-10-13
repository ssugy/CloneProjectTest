using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_6_Coroutine_1 : MonoBehaviour
{
    IEnumerator coroutine;
    private void Awake()
    {
        coroutine = Test_1();
    }
    IEnumerator Start()
    {
        StartCoroutine(coroutine);
        yield return null;
        Debug.Log("111111");
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(Test_1());
        yield return StartCoroutine(Test_2());
    }
    IEnumerator Test_1()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i + "_@");
            yield return null;
        }
    }
    IEnumerator Test_2()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i + "_#@");
            yield return null;
        }
    }
    void Update()
    {
        Debug.Log("*************************");
        if(Input.GetMouseButtonDown(0))
        {
            StopCoroutine(coroutine);
        }
    }
}
