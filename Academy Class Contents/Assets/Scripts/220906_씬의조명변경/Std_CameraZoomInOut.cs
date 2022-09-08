using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Std_CameraZoomInOut : MonoBehaviour
{
    Camera cam;

    // ������������ �ε巴�Ը����
    float scrollWheel, t, a, b;

    private void Start()
    {
        cam = GetComponent<Camera>();
        scrollWheel = 0; t = 0; a = cam.fieldOfView; b = cam.fieldOfView;
    }

    // ī�޶� ó���� lateUpdate���� ó��
    private void LateUpdate()
    {
        float s = Input.GetAxis("Mouse ScrollWheel");
        if (s != 0)
        {// ���� ���� �������� ���� t�� 0�̴�.
            scrollWheel = s;
            a = cam.fieldOfView;
            b = a + scrollWheel * 50f;
            t = 0f;
        }
        float curFov = Mathf.Lerp(a, b, t); // ���⼭ t�� t�ʸ��� �ȴٴ� �̾߱Ⱑ �ƴ϶�, �ۼ�Ʈ �����̶� 0~1���� ���̴�.
        t += 8f * Time.deltaTime;   // �̰Ŵ� �ۼ�Ʈ�� ������Ű�� �뵵�̸�, 1�ʿ� 8��ŭ Ŀ���ϱ�, 0.125�� ���� 0���� 1�� ����ȴ�.
        cam.fieldOfView = curFov;

        //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, b, Time.deltaTime * 8);   // �̷��� �ϴ°� ��������� �� �ٸ�. ���� �Ͱ� ���� �̵��ӵ��� �ƴ�.
    }
}
