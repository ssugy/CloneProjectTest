using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array_7_21 : MonoBehaviour
{
    // 1. 정수 6개를 저장할 배열을 선언
    // - 클래스에서 배열선언은 멤버변수로
    // - 초기화는 함수안에서 
    // 2. 값을 대입
    int[] arr;
    void Start()
    {
        arr = new int[6];
        arr[0] = 1;
        arr[1] = 2;
        arr[2] = 3;
        arr[3] = 4;
        arr[4] = 5;
        arr[5] = 6;
        Debug.Log(arr[0]);
        Debug.Log(arr[1]);
    }
    void Update()
    {
        
    }
}
