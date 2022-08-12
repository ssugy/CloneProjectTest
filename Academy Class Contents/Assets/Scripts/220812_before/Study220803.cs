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
        // �ٴ� ���ӿ�����Ʈ�� ������ ��� ������ ��ġ�� �����ϴ� �ڵ�
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
        //���̸� ���ߴ� �����, end���͸� �ٲ۴°� �ƴ϶�, transform.position���� �κ��� �����ؼ� ó������.
        // �ֳ��ϸ� end��ġ�� �̵��� �� ���ε�, �̵��� Y�� �̵��� ���� �ʱ� ����.
        Vector3 tmp = transform.position;
        tmp.y = end.y;
        Vector3 dir = end - tmp;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * rotateSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDir.normalized);
    }
}
