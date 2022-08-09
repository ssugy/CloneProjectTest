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
     * 1. ���� ���콺�� Ŭ���ϸ�, �ش� ��ġ�� �̵�.
     * 2. ĳ���� �ִϸ��̼ǰ� �Բ� �̵�
     */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // ���콺 ���� Ŭ���� �ѹ� ������ ��
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);    // ������ ������ ī�޶󿡼� ���콺 Ŭ���ϴ� ���������� ����
            //RaycastHit hitInfo;
            //if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity,1 << 8))
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Terrain"))
                {
                    //���� �ƹ����� ���ߴµ� ��� �ǳ�??????
                    //Ŭ���������� ������ ��ġ�� �����ϸ��
                    targetPos = hitInfo.point;
                    targetVec = targetPos - player.transform.position; // ������ ����(�������� ó���ϱ� ����)
                    END = targetPos;

                    //��򰡿� Ŭ���ϸ� ������ ��� ����� -> 1�ʵڿ� �ٽ� ���ݰ����ϰ� ����
                    isPlayerAbleAttack = false;
                    Invoke("PlayerAttackEnable",1f);
                    animator.SetInteger("PlayerState", 1);
                }
            }
        }
        
        
        //�̵� �Ϸ� - �ִϸ��̼ǿ� ���� ����
        //monster.transform.position = Vector3.MoveTowards(monster.transform.position, targetPos, speed * Time.deltaTime);

        // ������ ������ ������ ������ �̿��ؼ� �����ϸ�ȴ�.
        if (Vector3.Dot(player.transform.forward, targetVec.normalized) < 0.99f)
        {
            // ȸ�� ��� 1
            //monster.transform.LookAt(targetPos, Vector3.up * Time.deltaTime * 0.01f); 
            //monster.transform.rotation = Quaternion.Lerp(monster.transform.rotation
            //                                            , Quaternion.LookRotation(targetPos, Vector3.up)
            //                                            , Time.deltaTime * rotSpeed);
            
            // ȸ�� ���2
            //monster.transform.Rotate(Vector3.up * Time.deltaTime * 250);
        }

        //ȸ�����3 - �����ð� ���� (���� �ٶ󺸴¹���, ��ǥ���� ����, �����̴°���,)
        Vector3 dir = targetPos - player.transform.position;
        Vector3 newDir = Vector3.RotateTowards(player.transform.forward, dir.normalized, Time.deltaTime * rotSpeed, 0.0f);
        player.transform.rotation = Quaternion.LookRotation(newDir.normalized, Vector3.up);


        /* ���⸦ �ִϸ����� ��ũ��Ʈ�� ������)
        // �ִϸ��̼�
        // �������� �� ��ġ�� ������(�Ǵ� ������) int 0���� idle
        // �������� �� ��ġ�� �ٸ���(�Ǵ� �ָ�) int 1�� �ٲ۴�. run
        if (targetPos == monster.transform.position)
        {
            animator.SetInteger("PlayerState", 0);   // ����������
        }
        else
        {
            animator.SetInteger("PlayerState", 1);   // �۶�
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
