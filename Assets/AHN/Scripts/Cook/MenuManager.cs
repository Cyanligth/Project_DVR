using KIM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum Menu { Steak, Sushi }   

    public static List<List<string>> fishs = new List<List<string>>();    // �������� �ִ� ������

    public static List<List<string>> sasimiCounts = new List<List<string>>();   // ���� �� ���� ȸ ����
    // ������� ������ �����ǹǷ� sasimiCounts �� List�� �ּ�, {SalmonSushi,1}, {ASushi,4} �̷������� ��


    private void Start()
    {
        // fish list <fishInfo> 
        // fishInfo = name = 0, weight = 1, length = 2, FishRank = 3
        fishs = GameObject.FindObjectOfType<KIM_FishTank>().ReturnFishTankFishList();   // �������� �ִ� ������ ������ �޾ƿ�
    
        // sasimiCounts �� ���� ������ �̸��� [0]�� �� �ְ� [1]���� 0���� ����
        List<string> countInit = new List<string>();

        foreach (List<string> currentFishs in fishs)
        {
            // if (�ߺ� �̸��� �ִٸ� continue)

            string fishName = currentFishs[0];     // ù��° ����� name
            countInit.Add(fishName);
            countInit.Add("0");

            List<string> list = new List<string>();
            list = countInit;
            
            sasimiCounts.Add(list);     // { ����� �̸�, 0 } .. . .. �� �������� �ִ� ����Ʈ
        }
    }
}
