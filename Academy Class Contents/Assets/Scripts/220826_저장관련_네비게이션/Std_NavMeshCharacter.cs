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
        // 마우스 클릭한 위치로 에이전트 이동하기
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

        //오프셋 적용
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //스페이스바 키를 눌럿을 경우
            //진행방향의 뒤를 프로그램 코드로 작성하면 = 현재위치-목적지 벡터
            //시선방향의 뒤를 프로그램 코드로 작성하려면 = transform.forward
            navAgent.Move(-transform.forward * 3f); // 내 시선방향의 뒤의 방향으로
        }
    }

    //NavMesh.Raycast예제
    private void NavRaycastShow()
    {
        NavMeshHit navMeshHit;
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + transform.forward * 5;
        if (NavMesh.Raycast(startPos, endPos, out navMeshHit, NavMesh.AllAreas))
        {
            Debug.DrawLine(startPos, endPos, Color.red);    // scene창에서 볼 수 있다.
        }
        else
        {
            Debug.DrawLine(startPos, endPos, Color.green);
        }
    }
}
