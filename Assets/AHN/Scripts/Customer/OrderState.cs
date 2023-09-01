using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderState : StateMachineBehaviour
{
    StateCorutineManager corutineManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        corutineManager = animator.GetComponent<StateCorutineManager>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.SetTrigger("�ֹ��ϴ¾ִϸ��̼�); �̰� ���ุ ���ָ� ��.
        // 3�� ���� �ֹ��ϴ� �ִϸ��̼� ����Ǿ�� �ؼ� �ؿ� ���� �ڷ�ƾ �Լ��� �����ϴ� �� ������.
        corutineManager.StartCoroutine(corutineManager.OrderingRoutine());
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
