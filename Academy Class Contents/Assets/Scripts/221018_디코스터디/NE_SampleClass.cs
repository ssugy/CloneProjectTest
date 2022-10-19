using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE_SampleClass : MonoBehaviour
{
    // 이름, 나이
    string name = "나은";
    public int age = 10;
    public static int age2 = 10;

    //생성자?
    public NE_SampleClass()
    {
        //생성자
        Debug.Log("생성자 시작");
    }

    public NE_SampleClass(int a)
    {
        age = a;
        //생성자
        Debug.Log("생성자 시작");
    }

    /**
     * 오버로딩 : 이름이 같은데, 파라미터의 갯수가 다르거나  타입이 다르면 사용 가능
     * 버추얼 - 오버라이딩 : 상위 클래스에있는 함수를 하위 클래스에서 재정의 하는 것. 상위 클래스에서는 뭐가 필요한가요? 어떤 키워드?
     */


    public void ShowNE()
    {
        Debug.Log("ShowNE실행 " + age);
    }
    
    public static void ShowNE2()
    {
        Debug.Log("ShowNE실행 " + age2);
        Debug.Log("ShowNE실행");
    }
}
