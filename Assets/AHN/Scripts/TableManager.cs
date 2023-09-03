using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace AHN
{
    public class TableManager : MonoBehaviour
    {
        // GameManager���� tablemanager ������ �� �Ǵ� ������, TableManager�� �̹� seatSet�̶�� ��������Ʈ�� �޷��־ ������ �� ���� �Ǳ� ���� �ƴҰ�??
        public Dictionary<Transform, bool> SeatDic;    // �¼����� trasnform, á������á���� ���� bool

        private void Awake()
        {
            SeatDic = new Dictionary<Transform, bool>();
            AddDictionary();
        }

        void AddDictionary()    // �¼����� ��� SeatDic�� �ִ� ����
        {
            Transform[] seats = gameObject.GetComponentsInChildren<Transform>();

            foreach (Transform seat in seats)
            {
                Transform key = seat.transform;

                if (seat.name == "SeatSet")     // �ڱ� �ڽ��� ����
                    continue;
                else if (SeatDic.ContainsKey(key))
                    continue;

                SeatDic.Add(key, false);

            }
        }

        // ��ųʸ����� ���ڸ��� ã�� �Լ�. value���� False�� transforms���� ��ȯ��. customer�������� �� �Լ��� ȣ���Ͽ� �������
        public List<Transform> FalseSeat()
        {
            List<Transform> falseSeatsList = new List<Transform>();

            foreach (KeyValuePair<Transform, bool> seat in SeatDic)
            {
                if(seat.Value == false)
                {
                    falseSeatsList.Add(seat.Key);
                }
            }

            return falseSeatsList;
        }


        // �¼� ����
        public void SelectSeat()
        {
            // 1. ���¼��� ������
            //List<Transform> falseSeatList = GameManager.Table.FalseSeat();  -> �̰� �� �ȵǴ��� �𸣰���
            List<Transform> falseSeatList = FalseSeat();
 
            if (falseSeatList.Count <= 0)   // �¼� ������ ���� ����     
                return;
            // if (!seaDic.ContainsValue(false)) return; ���� �ص���. false�� value���� ���ٸ� return.

            // 2. falseSeatList���� �������� �ϳ��� �̾Ƽ� �� �¼����� ����
            int randomSeat = UnityEngine.Random.Range(0, falseSeatList.Count - 1);
            Transform customerSeat = falseSeatList[randomSeat];

            // 3. �� �¼��� value���� true�� ����
            SeatDic[falseSeatList[randomSeat]] = true; 
        }

        // TODO : �մ��� �� �԰� �������, �¼��� �ٽ� false�� �������־�� �ϴµ�,
        // �մ��� EatState�� ���� ��, �� ���¿��� �Լ��� �ϳ� �����. �׸��� �� �Լ��� �̺�Ʈ�� 

    }
}