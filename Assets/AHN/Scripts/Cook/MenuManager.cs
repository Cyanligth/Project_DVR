using KIM;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum Menu { Steak, Sushi }   

    public static List<List<string>> fishs = new List<List<string>>();    // �������� �ִ� ������

    public static List<List<string>> sasimiCounts = new List<List<string>>();    // ����⿡�� ���� ���� ����. {salmon, 7}, {Asasimi, 3} �̷�������.
    // ������� ������ �����ǹǷ� sasimiCounts �� List�� �ּ�, {SalmonSushi,1}, {ASushi,4} �̷������� ��

    // public static List<string> sasimiCounts = new List<string>();    // ����⿡�� ���� ���� ����. [0] = A�����, [1] = 4, [2] = B�����, [3] = 7  �̷�������.
    // public static string[] sasimiCounts;

    // Timer Bell�� ���� �� ����.
    public static void StoreFishListInTankRoutine()
    {
        // fish list <fishInfo> 
        // fishInfo = name = 0, weight = 1, length = 2, FishRank = 3
        fishs = GameObject.FindObjectOfType<KIM_FishTank>().ReturnFishTankFishList();   // �������� �ִ� ������ ������ �޾ƿ�
    
        List<string> countInit = new List<string>();    // sasimiCounts ����Ʈ�� ���� InnerList

        foreach (List<string> currentFishs in fishs)
        {
            // if (�ߺ� �̸��� �ִٸ� continue)
            string fishName = currentFishs[0];     // ù��° ����� name
            countInit.Add(fishName);
            countInit.Add("0");

            List<string> list = new List<string>();
            list = countInit.ToList();

            if (sasimiCounts.Count <= 0)    // ���� sasimiCounts�� ����Ʈ �����͸� ���� �ʾҴٸ�
            {
                sasimiCounts.Add(list);
            }

            foreach (List<string> innerSasimiCounts in sasimiCounts)    // �ߺ����� ��ġ�� ����� �̸��� �ִ��� Ȯ��
            {
                if (innerSasimiCounts[0] == fishName)
                {
                    break;
                }
                else
                {
                    sasimiCounts.Add(list);     // { ����� �̸�, 0 } .. . .. �� �������� �ִ� ����Ʈ
                    list.Clear();
                }
            }

        }
    }
}
