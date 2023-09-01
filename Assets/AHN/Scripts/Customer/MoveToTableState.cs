using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTableState : StateMachineBehaviour
{
    NavMeshAgent agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ���̺���� �ȴ� �ִϸ��̼� + ���̺���� �׺�Ž÷� �̵�.
        // �ٵ� ���ڰ� 7���� ġ�� �� 7�� �� ���������� ���� ���ڷ� ������.
        // ���ڴ� �迭�� ����. ����[0~6 ������]�� ���� �ŷ� ����
        // �������� �̹� ���ڿ� �ɾ� �ִٸ�. �� ���ڴ� bool isEmpty ��� ������ �ξ ����� ������ isEmpty = false;
        // for (int i = 0; i < ����.Length; ++i) �� ���ڸ� �� �ѷ�����
        // if (����[0~.isEmpty == true) �� �� �߿��� �������� �̰� �ű�� ����

        Debug.Log("MoveToTable");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
