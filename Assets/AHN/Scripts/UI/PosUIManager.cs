using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class PosUIManager : InGameUI
    {
        [SerializeField] GameObject mainScreen;
        [SerializeField] GameObject TotalSalesScreen;
        [SerializeField] GameObject FundScreen;

        private void Start()
        {
            mainScreen.SetActive(true);
            TotalSalesScreen.SetActive(false);
            FundScreen.SetActive(false);
        }

        public void TotalSalesButton()
        {
            Debug.Log("TotalSalesButton");
            // TODO : �Ѹ����� ���;� ��
            mainScreen.SetActive(false);
            TotalSalesScreen.SetActive(true);
        }


        public void FundButton()
        {
            // TODO : ������ �� �ں����� ���;� ��
            // 1. ���� ������Ʈ false
            mainScreen.SetActive(false);
            FundScreen.SetActive(true);
        }

        public void BackButton()
        {
            // �ٽ� MainScreen �ߵ���
            FundScreen.SetActive(false);
            TotalSalesScreen.SetActive(false);
            mainScreen.SetActive(true);
        }
    }
}