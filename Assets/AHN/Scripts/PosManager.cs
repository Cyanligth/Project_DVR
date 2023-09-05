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
        [SerializeField] GameObject orderSheet;     // �ֹ���
        private int totalSales;
        public int TotalSales { get { return totalSales; } set { totalSales = value; } }

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
        }

        IEnumerator AppearAddTextRoutine(int amount)
        {
            addSalesText.text = $"�����ݾ� : {amount}��";
            yield return new WaitForSeconds(5f);
            addSalesText.text = "";
        }
    }
}
