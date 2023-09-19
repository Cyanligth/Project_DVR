using KIM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AHN
{
    public class OrderState : StateMachineBehaviour
    {
        StateCorutineManager corutineManager;
        List<List<string>> fishs = new List<List<string>>();
        List<List<string>> fishsCopy = new List<List<string>>();
        List<string> fishInfo;
        GameObject orderSheet;
        Transform orderSheetPoolPosition;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            corutineManager = animator.GetComponent<StateCorutineManager>();
            orderSheet = GameManager.Resource.Load<GameObject>("OrderSheet");
            orderSheetPoolPosition = GameObject.Find("OrderSheetPoolPosition").transform;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            corutineManager.StartCoroutine(corutineManager.OrderingRoutine());
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // fish list <fishInfo> 
            // fishInfo = name = 0, weight = 1, length = 2, FishRank = 3
            // ���⼭ �ʿ��� �� 0, 3. (2�� ���߿�)
            fishs = GameObject.FindObjectOfType<KIM_FishTank>().ReturnFishTankFishList();   // �������� �ִ� ������ ������ �޾ƿ�
            List<List<string>> fishsCopy = new List<List<string>>(fishs);
            for (int i = 0; i < 5; i++) 
            {
                fishs.AddRange(fishsCopy);      // ����� �ϳ� �� ������ 5�� �����Ƿ� �迭 5�� ����
            }

            if (fishs.Count <= 0)
            {
                Debug.Log("����Ⱑ ���� �ֹ��� �Ұ����մϴ�.");
            }
            else
            {
                int orderFishIndex = Random.Range(0, fishs.Count);    // �ֹ��� ����� ����Ʈ ����
                fishInfo = fishs[orderFishIndex];   // �ֹ��� ������� 4�� ������ ����ִ� ����Ʈ

                // �ֹ��� ���
                GameManager.Instantiate(orderSheet, orderSheetPoolPosition.position, Quaternion.Euler(90f, 0, 0));
                orderSheet.GetComponent<OrderSheet>().MenuTextInput(fishInfo[0], animator.gameObject.GetComponent<Customer>().mySeatNumber());
                //                                                  ����� �̸�              ���̺� ��ȣ

                fishs.RemoveAt(orderFishIndex);     // �ֹ��� ����� �ε��� ����
            }
        }
    }
}