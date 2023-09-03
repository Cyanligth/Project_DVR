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
            agent = animator.GetComponent<NavMeshAgent>();
            animator.GetComponent<Customer>().SelectSeat();
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)  // Ű����ũ���� �ɾ�� ��
        {
            agent.destination = customer.kioskDestination.position;

            if (Vector3.Distance(animator.gameObject.transform.position, customer.kioskDestination.position) < 1f)
            {
                animator.SetTrigger("IsFrontKiosk");
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)    // Ű����ũ�� �� ������ ����
        {
            // �ʿ������
        }

        public void SelectSeat()    // �¼� ����
        {
            // 1. ���¼��� ������
            List<Transform> falseSeatList = GameManager.Table.FalseSeat();

            if (falseSeatList.Count <= 0)   // �¼� ������ ���� ���� 
                return;

            // 2. falseSeatList���� �������� �ϳ��� �̾Ƽ� �� �¼����� ����
            int randomSeat = Random.Range(0, falseSeatList.Count - 1);
            Transform mySeat = falseSeatList[randomSeat];
        }
    }
}