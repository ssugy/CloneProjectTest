using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Dictionary : MonoBehaviour
{
    // 키를 정수하고 값을 문자열로 하는 딕셔너리 선언
    Dictionary<int, string> dict;
    private void Awake()
    {
        dict = new Dictionary<int, string>();
    }

    private void Start()
    {
        dict.Add(0, "이승엽");
        dict.Add(1, "박찬호");
        dict.Add(2, "이효리");
        // 1. 키를 이용하여 값을 사용
        string result;
        if (dict.TryGetValue(0, out result))
        {
            // 0에 해당하는 값
            Debug.Log(result);
        }
        //
    }
}
