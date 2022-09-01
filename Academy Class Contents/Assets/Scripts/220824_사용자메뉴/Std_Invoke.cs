using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Invoke : MonoBehaviour
{
    private void Start()
    {
        //Invoke("ShowLog",5);  //�⺻���� invoke���
        InvokeRepeating("ShowLog", 3, 1);
    }

    private void ShowLog()
    {
        Debug.Log("�α��Դϴ�.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //CancelInvoke(); // ��� invoke ĵ��
            CancelInvoke("ShowLog");    // �����Ѱ͸� ���߱�
        }
    }
}
