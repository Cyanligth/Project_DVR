using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace AHN
{
    public class EatState : StateMachineBehaviour
    {
        StateCorutineManager corutineManger;
        int amount = 15;     // ������ �ݾ�. �ϴ� 15��� �������

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            corutineManger = animator.GetComponent<StateCorutineManager>();
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            corutineManger.StartCoroutine(corutineManger.EatRoutine());
            animator.SetTrigger("GoOut");
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            List<GameObject> plateAndFoods = animator.GetComponent<Customer>().mySeat.gameObject.GetComponentInChildren<FoodRecognitionOnTable>().PlateAndFood();

            foreach (GameObject plateAndFood in plateAndFoods)
            {
                if (plateAndFoods.Count <= 0)
                {
                    return;
                }    

                // ����
                if (plateAndFood.layer == 23)   // ���� ���� �� �ʹ��� �ִٸ�
                {
                    int myScore = plateAndFood.gameObject.GetComponent<SushiScore>().sushiScore;  // �� �ʹ��� ������ �޾ƿ�
                    PosManager.OnAddPayEvent?.Invoke(myScore);
                    Destroy(plateAndFood);      // ���̺� ���� �÷��� ���� �� �ʹ� ������
                }
                else
                {
                    animator.GetComponent<Customer>().mySeat.gameObject.GetComponentInChildren<FoodRecognitionOnTable>().IsPlateFalse();
                    Destroy(plateAndFood);      // ���̺� ���� �÷��� ���� �� �ʹ� ������
                }
            }
            plateAndFoods.Clear();
        }
    }
}