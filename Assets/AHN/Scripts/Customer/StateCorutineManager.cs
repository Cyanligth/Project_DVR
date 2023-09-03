using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class StateCorutineManager : MonoBehaviour
    {
        // StateMachine������ Corutine�� �� �Ǵϱ� ���⼭ �ڷ�ƾ �Լ��� �� �����ϰ�
        // State�ִϸ��̼� �ʿ��� animator.GetComponent<StateCorutineManager>�� �����ͼ� ��� ����

        Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public IEnumerator OrderingRoutine()    // �ֹ� �ڷ�ƾ
        {
            anim.SetTrigger("IsFrontKiosk");
            yield return new WaitForSeconds(3f);
            anim.SetTrigger("FinishedOrdering");
        }

        public IEnumerator FoodWaitRoutine()    // ���� ��ٸ��� �ڷ�ƾ
        {
            Debug.Log("Wait");
            yield return new WaitForSeconds(50f);
            Debug.Log("Angry");
            anim.SetTrigger("Angry");
            yield return new WaitForSeconds(10f);
            anim.SetTrigger("GoOut");
            // TODO : ���⼭ ���ӽð��� ���ҽ��Ѿ� �ҵ� (15�� ����)
            // �մ��� ���ӽð��� �����ؼ� �� �ð��� �����ϵ���
        }

        public IEnumerator EatRoutine()     // �Դ� �ڷ�ƾ
        {
            yield return new WaitForSeconds(7f);
            anim.SetTrigger("GoOut");
        }
    }
}