using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBtnStudy_220729: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �⺻ ���콺 �Է�
        /*if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left click.");
        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right click.");
        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");*/

        // ���콺 ���� ���� ��, ���콺 ��ǥ �ֺܼ信 ���
        //if (Input.GetMouseButtonDown(0))
        //{
        //    print(Input.mousePosition);
        //}

        //MouseButton();

        RotateOneSec();
    }

    private void MouseButton()
    {
        if (Input.GetMouseButton(0))
        {
            print("���콺 ���� ��ư ������ �ִ� ����");
        }
    }

    // 1�ʸ��� Y�� �������� 1���� ȸ���ϴ� �Լ�
    float timeCnt = 0;
    float angle;
    private void RotateOneSec()
    {
        timeCnt += Time.deltaTime;
        if (timeCnt >= 1)
        {
            timeCnt -= 1;

            transform.Rotate(Vector3.down * 1); //��� 1

            //transform.rotation *= Quaternion.Euler(Vector3.down); // ���2
        }
    }
}
