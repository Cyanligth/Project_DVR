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
            // TODO : ����.
            // KIM_FishTank ����Ʈ���� ����� ����� �޾ƿ�. ��޿� ���� �����ݾ��� �޶���.
            // + �����ϸ鼭 �����Ǵ� ����
            PosManager.OnPayEvent?.Invoke(amount);

            // TODO : ���ø� Ǯ�� �����ϴ��� Inst�װɷ� �����ϴ��� ���������. �ϴ� destroy�� �������� �س���

            List<GameObject> plateAndFoods = animator.GetComponent<Customer>().mySeat.gameObject.GetComponentInChildren<PlateRecognition>().PlateAndFood();

            foreach (GameObject plateAndFood in plateAndFoods)
            {
                Destroy(plateAndFood);
            }
        }
    }
}