using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBtnStudy_220729: MonoBehaviour
{
    Vector3 end;
    float moveSpeed = 2.5f;

    void Update()
    {
        #region 수업시간 내용
        // 기본 마우스 입력
        /*if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left click.");
        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right click.");
        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");*/

        // 마우스 왼쪽 누를 때, 마우스 좌표 콘솔뷰에 출력
        //if (Input.GetMouseButtonDown(0))
        //{
        //    print(Input.mousePosition);
        //}

        //MouseButton();

        //RotateOneSec();

        // 마우스 입력값 결과 출력
        /*float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if (x != 0)
            print($"마우스 X : {x}");
        if (y != 0)
            print($"마우스 Y : {y}");*/

        // 바닥찍어서 이동하게 만드는 함수
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            int layerMask = 1 << 6;
            layerMask = ~layerMask;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            {
                print("교차된 게임 오브젝트 이름 = " + hitInfo.collider.name);
                print("교차된 게임 오브젝트 이름 = " + hitInfo.point);
                end = hitInfo.point;
            }
        }
        // 클릭한 곳으로 이동
        transform.position = Vector3.MoveTowards(transform.position, end, moveSpeed * Time.deltaTime);
        #endregion
    }

    #region 수업시간 내용
    private void MouseButton()
    {
        if (Input.GetMouseButton(0))
        {
            print("마우스 왼쪽 버튼 누르고 있는 동안");
        }
    }

    // 1초마다 Y축 기준으로 1도씩 회전하는 함수
    float timeCnt = 0;
    float angle;
    private void RotateOneSec()
    {
        timeCnt += Time.deltaTime;
        if (timeCnt >= 1)
        {
            timeCnt -= 1;

            transform.Rotate(Vector3.up); //방법 1

            //transform.rotation *= Quaternion.Euler(0,1,0); // 방법2
        }
    }
    #endregion
}
