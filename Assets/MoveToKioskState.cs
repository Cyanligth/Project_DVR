using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToKioskState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)   // ���忡 �����ڸ��� �� ��
    {
        
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)  // Ű����ũ���� �ɾ�� ��
    {
        // �ִϸ��̼����� ��� �ɾ�ٰ� �����س��� Ű����ũ �� Position�� ���� 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)    // Ű����ũ�� �� ������ ����
    {
        
    }
}
