using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_PlayerPrefs : MonoBehaviour
{
    // PlayerPrefs�� static�Լ��� �̷�����ִ�. �׷��� �̷��� �ν��Ͻ� �����ؼ� �������� ����.
    //PlayerPrefs myPrefs;
    private void Start()
    {
        PlayerPrefs.SetString("ù��°","123");
        PlayerPrefs.Save(); // ��������
    }

    private void Update()
    {
        
    }
}
