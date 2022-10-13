using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Corountine : MonoBehaviour
{
    // Start is called before the first frame update
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
        yield return null;
        Debug.Log("12");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("#");
    }
}
