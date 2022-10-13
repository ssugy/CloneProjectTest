using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_1011Dictionary : MonoBehaviour
{
    // 일반적인 dictionary형태
    Dictionary<int, int> dict1;

    /**
     * 멀티맵
     * 키에 해당하는 값이 여러개일 경우
     * 키는 유일하다.(일반적인 Dictionary와 동일)
     * Dictionary<키, 리스트>
     */
    Dictionary<int, List<int>> dict2;    // 키:정수, 값:정수를 저장하는 리스트
    Dictionary<string, List<string>> dict3;    // 키:문자열, 값:문자열을 저장하는 리스트
    void Start()
    {
        dict1 = new Dictionary<int, int>();
        dict2 = new Dictionary<int, List<int>>();
        dict3 = new Dictionary<string, List<string>>();
        //값 저장
        dict1.Add(0, 100);
        dict1.Add(1, 102);

        // 키에 해당하는 값을 사용 dic1[0]이거랑 비슷하지만 키값이 있을 때 실행한다는 의미
        int findValue;
        if (dict1.TryGetValue(0, out findValue))
        {
            // 키에 해당하는 값이 존재하는 경우 findValue변수에 값이 저장
            //Debug.Log(findValue);
        }

        // 막간을 이용한 ref와 out
        // ref는 초기화 후 함수에 대입해야되고, out는 초기화 상관없이 함수에 대입할 수 있지만, out을 구현하는 함수에서는 값을 넣어주는 구문이 있어야 된다.
        int outData;
        TestOut(out outData);

        int refData = 100;
        TestRef(ref refData);

        // 멀티맵 클래스로 제어
        Std_Multimap<int,int> std = new Std_Multimap<int, int>();
        std.Add(0, 100);
        std.Add(0, 200);

        foreach (var item in std.GetData(0))
        {
            Debug.Log(item);
        }
    }

    private void TestOut(out int a)
    {
        a = 100;    //이걸 넣어야된다. 이거 안하면 에러뜸. ref는 넣기전에 초기화 해야되고, out은 여기에 초기화해야됨.
    }

    private void TestRef(ref int b)
    {

    }
}
