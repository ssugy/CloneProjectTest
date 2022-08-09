using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 단순테스트스크립트 : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake 함수 실행 1");
    }

    void Start()
    {
        Debug.Log("Start 함수 실행 2");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 함수 실행 3");
    }

    void Update()
    {
        Debug.Log("Update 함수 실행 4");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate 함수 실행 5");
    }
}
