using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollIdle : StateMachineBehaviour
{
    Std220808_Animator charactor;
    // 애니매이션 시작할 때 한번 실행됨. 반복애니매이션이면 1번만 실행되고, 다른것으로 변경되었다가 다시돌아올때에도 한번실행됨
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 내가 할려는게 정확하게 머냐? 케릭터 컴포넌트에 접근하려고함.(같은곳에 있다는 전제)
        charactor = animator.GetComponent<Std220808_Animator>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(charactor.END, animator.transform.position) < 0.1f)
        {
            // 현재위치가 목적지(end)위치와 같다면
            animator.SetInteger("PlayerState", 0);   // 이게 실행되는 순간 exit로 나가진다. 그리고 run에서 계속 빙빙돌게 된다.
            // 이렇게 코드를 작성하면 문제가 될 요소가 있는게, if문 안쪽의 조건식이 0.1f 여기 부분이 넓어지면 run과 idle이 서로 무제한으로 값을
            //바꾸는 문제가 생길 수 있다. SetInteger("MonsterRun", )이게 매 프레임마다 1과 0으로 계속 바뀔 수 있다.
            // 그래서 그냥 GameManager에서 if문으로 처리하면 그런 문제가 발생하지 않는데. 나눠지는게 정확하게 나눠지기 때문임.

            // 공격 가능한 상태일때
            if (charactor.isPlayerAbleAttack)
            {
                // 가만이 있을 때 적이 다가오면 공격
                for (int i = 0; i < charactor.enemys.Length; i++)
                {
                    if (Vector3.Distance(charactor.enemys[i].transform.position, charactor.transform.position) < 2)
                    {
                        Vector3 lookEnemyDir = charactor.enemys[i].transform.position - charactor.transform.position;
                        lookEnemyDir.y = 0; // 쳐다보는 각도 삐뚤어지지 않게 보정
                        charactor.transform.rotation = Quaternion.LookRotation(lookEnemyDir, Vector3.up);

                        animator.SetInteger("PlayerState", 2);
                    }
                }
            }
        }
        else
        {
            // 현재위치가 목적지와 다르다면(아직 목적지 도착전 = run해야됨)
            animator.SetInteger("PlayerState", 1);   // 그래서 여기 코드는 idle에서 하는게 아니라, run에서 해당 코드를 넣어야 된다.
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateExit : ");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    // 이건 뭐할때 쓰는건가?? OnStateUpdate랑 다른점은?
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //    Debug.Log("OnStateIK : ");
    //}
}
