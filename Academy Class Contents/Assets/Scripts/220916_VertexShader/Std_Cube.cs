using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Cube : MonoBehaviour
{
    public void 함수_퍼블릭()
    {
        Debug.Log("퍼블릭 함수 실행");
    }

    private void 함수_프라이빗()
    {
        Debug.Log("private 함수 실행");
    }

    private void Start()
    {
    }
}
