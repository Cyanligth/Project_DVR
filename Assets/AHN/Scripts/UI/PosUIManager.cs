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
        PosManager posManager;
        int a = 0;

        private void Start()
        {
            mainScreen.SetActive(true);
            TotalSalesScreen.SetActive(false);
            FundScreen.SetActive(false);
        }

        public void TotalSalesButton()
        {
            Debug.Log("TotalSalesButton");
            mainScreen.SetActive(false);
            TotalSalesScreen.SetActive(true);
            
            // TODO : �Ѹ����� ���;� �� -> ����Ƽ �̺�Ʈ�� �� �ʿ���� ������Ƽ�� ���������ϱ� �� ���� �����ͼ� text�� �����ֱ⸸ �ϸ� ��.
        }


        public void FundButton()
        {
            Debug.Log("FundButton");
            mainScreen.SetActive(false);
            FundScreen.SetActive(true);
            // TODO : ������ �� �ں����� ���;� ��
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