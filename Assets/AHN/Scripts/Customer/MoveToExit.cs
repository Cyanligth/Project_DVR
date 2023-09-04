using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class MoveToExit : StateMachineBehaviour
    {
        CustomerSqawnManager customerSqawn;
        Customer customer;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            customer = animator.GetComponent<Customer>();

            animator.GetComponent<Customer>().tableManager.ChangeValueFalse(animator.GetComponent<Customer>().mySeat);      // �ڱ� �ڸ��� false �� �ٲ�

            // TODO : Exit ���� Destination���� ��� ��������
            customerSqawn = GameObject.Find("CustomerSpawnPoint").GetComponent<CustomerSqawnManager>();
            animator.GetComponent<Customer>().agent.destination = customer.kioskDestination.position;

        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // ���⼭ �մ��� ����������. Ǯ������ ��Ȱ��ȭ.
            // if (Exit ���̶� �մ� �Ÿ��� 1�� �� �ȴٸ�)
            GameManager.Pool.Release(animator.gameObject);
        }
    }
}