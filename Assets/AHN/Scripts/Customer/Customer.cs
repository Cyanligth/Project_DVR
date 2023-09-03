using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class Customer : MonoBehaviour
    {
        // Ű����ũ ��, ���̺� ��, ������ �� �� �� ��ġ�� �� ������Ʈ�� �־ �� ������Ʈ�� ���ؼ� �� �� �ֵ�����.
        // ex.Ű����ũ �տ� �������Ʈ �ϳ� �ּ� customer�� �� �������Ʈ�� ���ؼ� move�ϵ���.

        public Transform customersPos;
        public Transform kioskDestination;
        public Transform mySeatDestination;     // ��� �巡�װ� �� ��. ���� �Ҵ��������.
        public float speed;
        //public Transform mySeat;
        [SerializeField] TableManager tableManager;

        private void Awake()
        {
            customersPos.position = transform.position;
        }

        // �¼� ����
        public void SelectSeat()
        {
            // 1. ���¼��� ������
            // List<Transform> falseSeatList = GameManager.Table.FalseSeat();  //-> �̰� �� �ȵǴ��� �𸣰��� (�ϴ� ���� gameObj�����ϱ� �װ� �ٿ���)
            List<Transform> falseSeatList = tableManager.FalseSeat();

            if (falseSeatList.Count <= 0)   // �¼� ������ ���� ����     
                return;

            // 2. falseSeatList���� �������� �ϳ��� �̾Ƽ� �� �¼����� ����
            int randomSeat = UnityEngine.Random.Range(0, falseSeatList.Count - 1);
            mySeatDestination = falseSeatList[randomSeat];

            // 3. �� �¼��� value���� true�� ����
            // GameManager.Table.SeatDic[falseSeatList[randomSeat]] = true;
            tableManager.SeatDic[falseSeatList[randomSeat]] = true;
        }
    }
}