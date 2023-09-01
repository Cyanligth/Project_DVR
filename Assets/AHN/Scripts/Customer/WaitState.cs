using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : StateMachineBehaviour
{
    StateCorutineManager corutineManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // �ð� ��� ����!

        corutineManager = animator.GetComponent<StateCorutineManager>();
        corutineManager.StartCoroutine(corutineManager.FoodWaitRoutine());  // 60�� ���� ����
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if (�� ���̺� ������ �÷����ٸ�)
        // animator.Settrigger("Eat");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // �ð� �ʱ�ȭ
        // corutineManager.StopCoroutine(corutineManager.FoodWaitRoutine());
    }
}
