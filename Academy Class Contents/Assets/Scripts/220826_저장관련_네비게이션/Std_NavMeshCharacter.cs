using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Std_NavMeshCharacter : MonoBehaviour
{
    NavMeshAgent navAgent;
    Vector3 targetPos;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        // ���콺 Ŭ���� ��ġ�� ������Ʈ �̵��ϱ�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Terrain"))
                {
                    targetPos = hitInfo.point;
                    navAgent.destination = targetPos;
                }
            }
        }

        NavRaycastShow();

        //������ ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�����̽��� Ű�� ������ ���
            //��������� �ڸ� ���α׷� �ڵ�� �ۼ��ϸ� = ������ġ-������ ����
            //�ü������� �ڸ� ���α׷� �ڵ�� �ۼ��Ϸ��� = transform.forward
            navAgent.Move(-transform.forward * 3f); // �� �ü������� ���� ��������
        }
    }

    //NavMesh.Raycast����
    private void NavRaycastShow()
    {
        NavMeshHit navMeshHit;
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + transform.forward * 5;
        if (NavMesh.Raycast(startPos, endPos, out navMeshHit, NavMesh.AllAreas))
        {
            Debug.DrawLine(startPos, endPos, Color.red);    // sceneâ���� �� �� �ִ�.
        }
        else
        {
            Debug.DrawLine(startPos, endPos, Color.green);
        }
    }
}
