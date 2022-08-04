using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study220803 : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;
    Vector3 end;
    float rotateSpeed = 5;

    private void Start()
    {
        
    }

    private void Update()
    {
        // 바닥 게임오브젝트를 선택할 경우 선택한 위치를 저장하는 코드
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.gameObject.CompareTag("Terrain"))
                {
                    end = hitInfo.point;
                    print(hitInfo.point);
                }
            }
        }
        //높이를 맞추는 방법을, end벡터를 바꾼는게 아니라, transform.position여기 부분을 변경해서 처리해줌.
        // 왜냐하면 end위치로 이동을 할 것인데, 이동시 Y축 이동을 하지 않기 위함.
        Vector3 tmp = transform.position;
        tmp.y = end.y;
        Vector3 dir = end - tmp;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * rotateSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDir.normalized);
    }
}
