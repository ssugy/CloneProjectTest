using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBtnStudy_220729: MonoBehaviour
{
    Vector3 end;
    float moveSpeed = 2.5f;

    void Update()
    {
        #region �����ð� ����
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

        //RotateOneSec();

        // ���콺 �Է°� ��� ���
        /*float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if (x != 0)
            print($"���콺 X : {x}");
        if (y != 0)
            print($"���콺 Y : {y}");*/

        // �ٴ��� �̵��ϰ� ����� �Լ�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            int layerMask = 1 << 6;
            layerMask = ~layerMask;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            {
                print("������ ���� ������Ʈ �̸� = " + hitInfo.collider.name);
                print("������ ���� ������Ʈ �̸� = " + hitInfo.point);
                end = hitInfo.point;
            }
        }
        // Ŭ���� ������ �̵�
        transform.position = Vector3.MoveTowards(transform.position, end, moveSpeed * Time.deltaTime);
        #endregion
    }

    #region �����ð� ����
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

            transform.Rotate(Vector3.up); //��� 1

            //transform.rotation *= Quaternion.Euler(0,1,0); // ���2
        }
    }
    #endregion
}
