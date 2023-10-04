using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class WaitState : StateMachineBehaviour
    {
        StateCorutineManager corutineManager;
        Transform table;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            corutineManager = animator.GetComponent<StateCorutineManager>();
            corutineManager.StartCoroutine(corutineManager.FoodWaitRoutine());  // 60�� ���� ����

            // ���̺� ������ �ٶ󺸵���
            table = animator.GetComponent<Customer>().mySeat.GetChild(0).transform;
            animator.transform.LookAt(table);
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // if (�� ���̺� ������ �÷����ٸ�)
            if (animator.GetComponent<Customer>().mySeat.gameObject.GetComponentInChildren<FoodRecognitionOnTable>().IsPlate())
            {
                // TODO : IsPlate. �� �԰� ������ �� false �� ���� �� ������?
                animator.SetTrigger("Eat");
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // ��ٸ��� �ڷ�ƾ Stop
            corutineManager.StopCoroutine(corutineManager.FoodWaitRoutine());
        }
    }
}
