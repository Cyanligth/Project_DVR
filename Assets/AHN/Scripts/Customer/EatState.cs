using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class EatState : StateMachineBehaviour
    {
        StateCorutineManager corutineManger;

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
            // �ϼ��� �ʹ信 �̹� �ִ� int(������)�� �޾ƿðǵ�, �ʹ信�� int(������)�� ��ȯ�ϴ� �Լ��� ����� ����Ƽ �̺�Ʈ�� �� �Լ��� ����
        }
    }
}