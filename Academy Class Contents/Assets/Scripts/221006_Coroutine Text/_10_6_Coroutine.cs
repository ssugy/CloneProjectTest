using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_6_Coroutine : MonoBehaviour
{
    void Start()
    {
        Debug.Log("4");
        StartCoroutine(DisplayData());
    }
    IEnumerator DisplayData()
    {
        Debug.Log("3");
        yield return null;
        Debug.Log("11");
    }
    void Update()
    {
        Debug.Log("#");
    }
}
