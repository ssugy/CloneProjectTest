using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_PlayerPrefs : MonoBehaviour
{
    // PlayerPrefs는 static함수로 이루어져있다. 그래서 이렇게 인스턴스 생성해서 진행하지 않음.
    //PlayerPrefs myPrefs;
    private void Start()
    {
        PlayerPrefs.SetString("첫번째","123");
        PlayerPrefs.Save(); // 저장해줌
    }

    private void Update()
    {
        
    }
}
