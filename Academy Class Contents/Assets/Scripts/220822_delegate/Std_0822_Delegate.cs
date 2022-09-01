using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 이름이 Do인 델리게이트 선언
delegate void Do();

public class Std_0822_Delegate : MonoBehaviour
{
    //2. Do형 변수 deFunction을 선언
    Do deFunction;

    void Start()
    {
        //3. 델리게이트 변수에 사용하고자 하는 함수를 대입
        deFunction = Displaydata;
        //4. 델리게이트 변수를 호출
        deFunction();
    }

    void Displaydata()
    {
        Debug.Log("DisplayData");
    }

    // Update is called once per frame
    void Update()
    {
        if (deFunction != null)
        {
            deFunction();   // 이렇게 사용할 수 있다. 그때그때마다 함수를 대입해서 사용하면 된다.
        }
    }
}
