using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class MoveToExit : StateMachineBehaviour
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // ���� ������ anim�� angry���ٸ�, �� �ð��� (15�� ����)���ҽ��Ѿ� ��!
            // �̰� ����Ƽ �̺�Ʈ�� �޾ƿ;� �ϳ�...
            // �ϴ� StateCorutineManager���� �����ϵ��� ����
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // ���⼭ �մ��� ����������. ��Ȱ��ȭ�ؼ� Ǯ������ �����ص� ��������. �ٵ� �ϴ��� Destroy�� ���� ��
        }
    }
}