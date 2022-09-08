using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Std_CameraZoomInOut : MonoBehaviour
{
    Camera cam;

    // 선형보간으로 부드럽게만들기
    float scrollWheel, t, a, b;

    private void Start()
    {
        cam = GetComponent<Camera>();
        scrollWheel = 0; t = 0; a = cam.fieldOfView; b = cam.fieldOfView;
    }

    // 카메라 처리는 lateUpdate에서 처리
    private void LateUpdate()
    {
        float s = Input.GetAxis("Mouse ScrollWheel");
        if (s != 0)
        {// 내가 휠을 움직였을 때의 t는 0이다.
            scrollWheel = s;
            a = cam.fieldOfView;
            b = a + scrollWheel * 50f;
            t = 0f;
        }
        float curFov = Mathf.Lerp(a, b, t); // 여기서 t는 t초만에 된다는 이야기가 아니라, 퍼센트 개념이라서 0~1사이 값이다.
        t += 8f * Time.deltaTime;   // 이거는 퍼센트를 증가시키는 용도이며, 1초에 8만큼 커지니까, 0.125초 만에 0에서 1로 변경된다.
        cam.fieldOfView = curFov;

        //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, b, Time.deltaTime * 8);   // 이렇게 하는건 비슷하지만 좀 다름. 위에 것과 같은 이동속도는 아님.
    }
}
