using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace AHN
{
    public class PosManager : MonoBehaviour
    {
        public static UnityEvent<int> OnPayEvent = new UnityEvent<int>();   // EatState���� ȣ���� event
        [SerializeField] TMP_Text paymentAmountText;
        [SerializeField] TMP_Text totalSalesText;
        [SerializeField] TMP_Text fundText;
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
            OnPayEvent.AddListener(TotalSalesText);
            OnPayEvent.AddListener(PaymentAmountText);
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

        void TotalSalesText(int amount)   // �Ѹ���
        {
            totalSales += amount;
            totalSalesText.text = $"Total Sales : {totalSales}";

            // TODO : �Ϸ縶�� ���� �ʱ�ȭ

        }

        void FundText(int totalSales)   // ���� �� �ں�
        {
            // ��� ���� �� ���ϱ�

        }

        public void PaymentAmountText(int amount)   // �����ݾ�
        {
            StartCoroutine(AppearPaymentAmountRoutine(amount));
            TotalSalesText(amount);
            
            PrintOrderSheet();
        }

        IEnumerator AppearPaymentAmountRoutine(int amount)
        {
            paymentAmountText.text = $"amount : {amount}";
            yield return new WaitForSeconds(5f);
            paymentAmountText.text = "";
        }

    }
}
