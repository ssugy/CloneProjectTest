using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE_Class2 : MonoBehaviour
{
    public int num1;

    // 함수를 하나 만들것이에요. -> 이 함수를 실행시키면, num1의 값을 출력하는 것.
    public void ShowNum(int data)
    {
        num1 = data;
        Debug.Log("내부함수 실행" + num1);
    }
    
    public void ShowNum()
    {
        Debug.Log("내부함수 실행" + num1);
    }
}
