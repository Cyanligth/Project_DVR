using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AHN
{
    public class MoveToKioskState : StateMachineBehaviour
    {
        Customer customer;
        NavMeshAgent agent;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)   // ���忡 �����ڸ��� �� ��
        {
            customer = animator.GetComponent<Customer>();
            agent = animator.GetComponent<NavMeshAgent>();  // ���⼭ ���̸Ž��� ������
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)  // Ű����ũ���� �ɾ�� ��
        {
            Debug.Log("MoveToKiosk");

            agent.destination = customer.KioskDestination.position;

            if (Vector3.Distance(animator.gameObject.transform.position, customer.KioskDestination.position) < 1f)
            {
                animator.SetTrigger("IsFrontKiosk");
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)    // Ű����ũ�� �� ������ ����
        {
            // �ʿ������
        }
    }
}