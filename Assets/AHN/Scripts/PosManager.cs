using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AHN
{
    public class PosManager : MonoBehaviour
    {
        public static UnityEvent<int> OnPayEvent = new UnityEvent<int>();
        [SerializeField] TextMesh addSalesText;
        [SerializeField] TextMesh totalSalesText;
        [SerializeField] Transform orderSheetPoolPosition;
        GameObject orderSheet;     // �ֹ���
        private int totalSales;
        public int TotalSales { get { return totalSales; } set { totalSales = value; } }

        private void Start()
        {
            orderSheet = GameManager.Resource.Load<GameObject>("OrderSheet");
            orderSheetPoolPosition = GameObject.Find("OrderSheetPoolPosition").GetComponent<Transform>();
        }

        private void OnEnable()
        {
            OnPayEvent.AddListener(IncreaseInSales);
            OnPayEvent.AddListener(AddText);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        // 1. TODO : �ֹ�����Լ�
        public void PrintOrderSheet()
        {
            // Customer�� Orderstate-Exit()���� ȣ���� �ֹ�����Լ�()
            // �ֹ�����Լ�()���� ������ �տ� �޴��� ���� �ֹ����� ���ϰ� ����� �Լ�.
            // *�ֹ����� Grab Interactable
            // �ֹ����� �մ� ����ŭ �����Ǵϱ� �ֹ����� Ǯ������ �ؾ��ϳ�?
            // �ֹ����� �մ��� Seat�� �����ϴ� ��ó�� �̹� �ִ� �޴��� �������� ����
            orderSheet = GameManager.Pool.Get(orderSheet, orderSheetPoolPosition.position, Quaternion.identity);

            // TODO : �ֹ��� ���߿� Release ����� �ϴµ� �װ� ���߿�,,,
        }

        void IncreaseInSales(int amount)
        {
            totalSales += amount;
            totalSalesText.text = $"�հ� : {totalSales}";
        }

        public void AddText(int amount)
        {
            StartCoroutine(AppearAddTextRoutine(amount));
            IncreaseInSales(amount);    // �Ѹ��� �÷���
            
            
            PrintOrderSheet();
        }

        IEnumerator AppearAddTextRoutine(int amount)
        {
            addSalesText.text = $"�����ݾ� : {amount}��";
            yield return new WaitForSeconds(5f);
            addSalesText.text = "";
        }
    }
}
