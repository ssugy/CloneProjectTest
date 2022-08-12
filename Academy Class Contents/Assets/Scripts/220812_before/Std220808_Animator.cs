using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std220808_Animator : MonoBehaviour
{
    Vector3 end;
    public Vector3 END
    {
        get { return end; }
        set { end = value; }
    }

    private int num;
    public GameObject player;
    public GameObject[] enemys;
    public bool isPlayerAbleAttack;
    private Animator animator;

    private float moveSpeed;
    public float SPEED
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public float rotSpeed = 40;

    private Vector3 targetPos;
    private Vector3 targetVec;
    
    void Start()
    {
        isPlayerAbleAttack = true;
        moveSpeed = 1.5f;
        animator = player.GetComponent<Animator>();
        targetVec = player.transform.forward;
    }

    public Camera myCam;
    private RaycastHit hitInfo;
    /**
     * 1. 내가 마우스로 클릭하면, 해당 위치로 이동.
     * 2. 캐릭터 애니매이션과 함께 이동
     */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // 마우스 왼쪽 클릭을 한번 눌렀을 때
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);    // 광선의 방향은 카메라에서 마우스 클릭하는 지점으로의 광선
            //RaycastHit hitInfo;
            //if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity,1 << 8))
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Terrain"))
                {
                    //여기 아무짓도 안했는데 어떻게 되냐??????
                    //클릭했을때에 목적지 위치를 저장하면됨
                    targetPos = hitInfo.point;
                    targetVec = targetPos - player.transform.position; // 목적지 방향(내적으로 처리하기 위해)
                    END = targetPos;

                    //어딘가에 클릭하면 공격을 잠시 멈춘다 -> 1초뒤에 다시 공격가능하게 변경
                    isPlayerAbleAttack = false;
                    Invoke("PlayerAttackEnable",1f);
                    animator.SetInteger("PlayerState", 1);
                }
            }
        }
        
        
        //이동 완료 - 애니매이션에 직접 넣음
        //monster.transform.position = Vector3.MoveTowards(monster.transform.position, targetPos, speed * Time.deltaTime);

        // 목적지 각도는 벡터의 내적을 이용해서 정의하면된다.
        if (Vector3.Dot(player.transform.forward, targetVec.normalized) < 0.99f)
        {
            // 회전 방법 1
            //monster.transform.LookAt(targetPos, Vector3.up * Time.deltaTime * 0.01f); 
            //monster.transform.rotation = Quaternion.Lerp(monster.transform.rotation
            //                                            , Quaternion.LookRotation(targetPos, Vector3.up)
            //                                            , Time.deltaTime * rotSpeed);
            
            // 회전 방법2
            //monster.transform.Rotate(Vector3.up * Time.deltaTime * 250);
        }

        //회전방법3 - 수업시간 내용 (내가 바라보는방향, 목표지점 방향, 움직이는각도,)
        Vector3 dir = targetPos - player.transform.position;
        Vector3 newDir = Vector3.RotateTowards(player.transform.forward, dir.normalized, Time.deltaTime * rotSpeed, 0.0f);
        player.transform.rotation = Quaternion.LookRotation(newDir.normalized, Vector3.up);


        /* 여기를 애니매이터 스크립트로 변경함)
        // 애니매이션
        // 목적지와 내 위치가 같으면(또는 가까우면) int 0으로 idle
        // 목적지와 내 위치가 다르면(또는 멀면) int 1로 바꾼다. run
        if (targetPos == monster.transform.position)
        {
            animator.SetInteger("PlayerState", 0);   // 멈춰있을때
        }
        else
        {
            animator.SetInteger("PlayerState", 1);   // 뛸때
        }
        */
    }

    private void PlayerAttackEnable()
    {
        isPlayerAbleAttack = true;
    }

    public void OnButtonClick()
    {

    }
}
