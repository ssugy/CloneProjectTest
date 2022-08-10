using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1. 시작시 리소스로드하여 화면에 배치 ( 높낮이에 상관없는 몬스터 배치 ) - GameManager.cs
 * 2. 마우스 픽킹(Picking)에 의한 캐릭터 이동 구현 - GameManager.cs // Character.cs
 * 3. 마우스로 캐릭터 선택시 콘솔뷰에 캐릭터 이름 출력 - GameManager.cs
 * 4. 캐릭터가 이동시 카메라는 초기의 거리를 유지한 채로 캐릭터를 따라서 이동한다. 단 ,캐릭터의 회전은 카메라에 적용되지 않는다.
 */
public class GameManager_DevYH : MonoBehaviour
{
    // 1. 메모리 재사용을 위한 게임오브젝트 선언 - Instantiate를 여러번 할 수도 있다는 확장성 생각
    GameObject character;

    // 2. 마우스 피킹을 위한 캐릭터 이동 구현용 변수 선언
    Character_DevYH playerCharacter;
    CameraManager_DevYH cameraManager;
    BoxCollider boxCollider;
    Vector3 targetPos;    // 목적지 위치
    
    void Start()
    {
        // 1. 시작시 리소스로드하여 화면에 배치 ( 높낮이에 상관없는 몬스터 배치 )
        character = Instantiate(Resources.Load<GameObject>("TrollGiant") , Vector3.zero, Quaternion.identity);

        // 초기값 지정
        playerCharacter = character.AddComponent<Character_DevYH>();
        boxCollider = character.AddComponent<BoxCollider>();  // player에게 맞는 콜라이더 추가.(체크를 위한 콜라이더 추가)
        boxCollider.size = new Vector3(2, 2, 1);              // 캐릭터에 맞는 콜라이더 지정
        boxCollider.center = new Vector3(0, 1, 0);
        character.layer = 6;    // player 레이어 부여
        character.tag = "Player";
        character.name = "용사";
        
        // 4. 카메라에 컴포넌트 추가
        cameraManager = Camera.main.gameObject.AddComponent<CameraManager_DevYH>();
        cameraManager.TargetPlayer = character;
        cameraManager.InitCameraPosRot();    // 카메라 위치/회전 초기화
    }

    void Update()
    {
        // 2.마우스 픽킹(Picking)에 의한 캐릭터 이동 구현
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                // 레이어가 아닌 태그를 이용한 분리. 이렇게 하면 캐릭터를 클릭하면 이름이 출력되고 이동은 되지 않습니다.
                // 3. 마우스로 캐릭터 선택시 콘솔뷰에 캐릭터 이름 출력
                if (hitInfo.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("캐릭터 이름 : " + hitInfo.collider.gameObject.name);
                }
                else
                {
                    targetPos = hitInfo.point;
                }
            }
        }

        // 2.마우스 픽킹(Picking)에 의한 캐릭터 이동 구현
        playerCharacter.MoveCharacter(targetPos);
        playerCharacter.RotCharacter(targetPos);    // 회전구현

        // 4. 플레이어 이동에 따른 카메라 동시 이동
        cameraManager.TracePlayer();
    }
}
