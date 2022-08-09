using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAttack : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 1. 적이 다 죽는 경우 idle로 이동

        // 2. 내가 다른곳으로 클릭하면 공격을 멈추고 이동
        // 내가 다른곳으로 클릭한다 => 공격을 1초동안 멈추고 이동한다. = 이건 attack에서 하는게 아니라, 클릭할때 해야된다.
        // 또는 적이 물러난다 => 이건 상태 고민좀 해야됨. 쫓아가게 할 것인지, 아니면 그냥 멈춰있을것인지

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
