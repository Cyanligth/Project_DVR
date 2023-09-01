using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToKioskState : StateMachineBehaviour
{
    Customer customer;
    NavMeshAgent agent;
    float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)   // ���忡 �����ڸ��� �� ��
    {
        timer = 0f;
        customer = animator.GetComponent<Customer>();
        agent = animator.GetComponent<NavMeshAgent>();  // ���⼭ ���̸Ž��� ������
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)  // Ű����ũ���� �ɾ�� ��
    {
        Debug.Log("MoveToKiosk");

        agent.destination = customer.destination.position;      // �̷��� �ϸ� detination���� ���� ����ε�
                                                                // customer.destinaton�� Ű����ũ ���� �� ����.
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            animator.SetTrigger("IsFrontKiosk");
            timer = 0f;
        }

        // if (customer�� pos�� desination�� �Ÿ��� < 1f) �̸�, animator.SetTrigger("�ֹ��ϴ°�");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)    // Ű����ũ�� �� ������ ����
    {
        // �ʿ������
    }
}
