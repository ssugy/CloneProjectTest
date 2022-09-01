using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Invoke : MonoBehaviour
{
    private void Start()
    {
        //Invoke("ShowLog",5);  //기본적인 invoke사용
        InvokeRepeating("ShowLog", 3, 1);
    }

    private void ShowLog()
    {
        Debug.Log("로그입니다.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //CancelInvoke(); // 모든 invoke 캔슬
            CancelInvoke("ShowLog");    // 선택한것만 멈추기
        }
    }
}
