using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 구조체(struct)
// 값타입의 사용자 정의 자료형
public struct Data
{
    public int data1;
    public float data2;
    public void Test()
    {
    }
}
// 열거체(enum)
// 값타입의 사용자 정의 자료형
// 단어에 숫자의 값을 적용해서 사용
// 첫번째 데이터는 초기값을 대입하지 않는 다면 0으로 시작하고 다음 데이터 부터 1씩 숫자의 값이 증가
public enum eDATA
{
    NONE = 100,
    BLACK = 2,
    TWO
}
public class DataType_7_28 : MonoBehaviour
{
    void Start()
    {
        Debug.Log((int)eDATA.NONE);
        Debug.Log(eDATA.BLACK);
        Debug.Log(eDATA.TWO);
        // 사용예
        int userData = 23;
        if(userData == (int)eDATA.BLACK)
        {
            //userData가 eDATA.BLACK과 같다면
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
