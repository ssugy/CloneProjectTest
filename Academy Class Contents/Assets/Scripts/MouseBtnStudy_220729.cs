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

        RotateOneSec();
    }

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

            transform.Rotate(Vector3.down * 1); //방법 1

            //transform.rotation *= Quaternion.Euler(Vector3.down); // 방법2
        }
    }
}
