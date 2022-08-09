using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollIdle : StateMachineBehaviour
{
    Std220808_Animator charactor;
    // �ִϸ��̼� ������ �� �ѹ� �����. �ݺ��ִϸ��̼��̸� 1���� ����ǰ�, �ٸ������� ����Ǿ��ٰ� �ٽõ��ƿö����� �ѹ������
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ���� �ҷ��°� ��Ȯ�ϰ� �ӳ�? �ɸ��� ������Ʈ�� �����Ϸ�����.(�������� �ִٴ� ����)
        charactor = animator.GetComponent<Std220808_Animator>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(charactor.END, animator.transform.position) < 0.1f)
        {
            // ������ġ�� ������(end)��ġ�� ���ٸ�
            animator.SetInteger("PlayerState", 0);   // �̰� ����Ǵ� ���� exit�� ��������. �׸��� run���� ��� �������� �ȴ�.
            // �̷��� �ڵ带 �ۼ��ϸ� ������ �� ��Ұ� �ִ°�, if�� ������ ���ǽ��� 0.1f ���� �κ��� �о����� run�� idle�� ���� ���������� ����
            //�ٲٴ� ������ ���� �� �ִ�. SetInteger("MonsterRun", )�̰� �� �����Ӹ��� 1�� 0���� ��� �ٲ� �� �ִ�.
            // �׷��� �׳� GameManager���� if������ ó���ϸ� �׷� ������ �߻����� �ʴµ�. �������°� ��Ȯ�ϰ� �������� ������.

            // ���� ������ �����϶�
            if (charactor.isPlayerAbleAttack)
            {
                // ������ ���� �� ���� �ٰ����� ����
                for (int i = 0; i < charactor.enemys.Length; i++)
                {
                    if (Vector3.Distance(charactor.enemys[i].transform.position, charactor.transform.position) < 2)
                    {
                        Vector3 lookEnemyDir = charactor.enemys[i].transform.position - charactor.transform.position;
                        lookEnemyDir.y = 0; // �Ĵٺ��� ���� �߶Ծ����� �ʰ� ����
                        charactor.transform.rotation = Quaternion.LookRotation(lookEnemyDir, Vector3.up);

                        animator.SetInteger("PlayerState", 2);
                    }
                }
            }
        }
        else
        {
            // ������ġ�� �������� �ٸ��ٸ�(���� ������ ������ = run�ؾߵ�)
            animator.SetInteger("PlayerState", 1);   // �׷��� ���� �ڵ�� idle���� �ϴ°� �ƴ϶�, run���� �ش� �ڵ带 �־�� �ȴ�.
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateExit : ");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    // �̰� ���Ҷ� ���°ǰ�?? OnStateUpdate�� �ٸ�����?
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
