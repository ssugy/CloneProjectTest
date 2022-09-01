using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1. Ray를 이용한 지형 높이 계산
 * 2. 게임 실행 시 10개의 큐브(프리팹)를 로드하고 바닥지형의 높이에 상관없이 큐브를 배치하는 프로그램 코드 작성.
 * 단 큐브는 바닥의 범위를 벗어날 수 없다.
 * 큐브에는 Monster라는 스크립트를 생성시 추가한다.
 */
public class Std_0818_MakeCube : MonoBehaviour
{

    private void Start()
    {
        MakeCube();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                print("Found an object - distance : " + hit.distance);
            }
        }
    }

    private void MakeCube()
    {
        GameObject go = Resources.Load<GameObject>("Character/Cube");
        for (int i = 0; i < 10; i++)
        {
            Instantiate(go, CalcSpawnPos(), Quaternion.identity);
        }
    }

    public Transform[] spawnTransform;  // 위에서 볼 때 0번이 좌측 하단, 1번이 우측 상단
    
    // 큐브가 생성 될 위치 확인
    private Vector3 CalcSpawnPos()
    {
        // 1. 생성 범위를 지정 - 빈게임 오브젝트 2개로 지정 -> 생성범위내에 랜덤한 좌표를 지정
        Vector3 spawnPos = new Vector3(Random.Range(spawnTransform[0].position.x, spawnTransform[1].position.x)
                                        , 100
                                        , Random.Range(spawnTransform[0].position.z, spawnTransform[1].position.z));

        // 2. 랜덤한 좌표에서 -Vector3.up방향의 레이캐스트를 쏴서 hit되는 위치를 반환 -> 여기서 cube만나면 다시 리롤 돌리게 하기.
        //그런데 그렇게하면, 큐브끼리 겹칠 수도있다. 그래서 정확한건, 각 큐브의 위치를 저장해서  거리를 확인한 뒤, 범위겹치면 다시 리롤 돌리게 해야된다.
        RaycastHit hit;
        Physics.Raycast(spawnPos, -Vector3.up, out hit);
        
        return hit.point;   // 바닥의 범위를 벗어나지 않는다고 하니, 예외처리 안하긴함
    }

    
}
