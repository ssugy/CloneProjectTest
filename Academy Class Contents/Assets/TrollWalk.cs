using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 이동할때 애니매이션
 */
public class TrollWalk : StateMachineBehaviour
{
    Std220808_Animator charactor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        charactor = animator.GetComponent<Std220808_Animator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (charactor.transform.position == charactor.END)
        {
            animator.SetInteger("PlayerState", 0);
        }
        else
        {
            if (charactor.isPlayerAbleAttack)
            {
                for (int i = 0; i < charactor.enemys.Length; i++)
                {
                    if (Vector3.Distance(charactor.enemys[i].transform.position, charactor.transform.position) < 2)
                    {
                        animator.SetInteger("PlayerState", 2);
                    }
                }
            }

            Move();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // 함수정의 - 이동할때 적만나면 이동멈춤
    private void Move()
    {
        
        charactor.transform.position = Vector3.MoveTowards(charactor.transform.position
                                                    , charactor.END
                                                    , Time.deltaTime * charactor.SPEED);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
