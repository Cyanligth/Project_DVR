using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace AHN
{
    public class RawFishTrigger : MonoBehaviour
    {
        [SerializeField] GameObject sushiManager;
        [SerializeField] GameObject rice;
        public int sushiScore;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 21)   // ȸ�� trigger�Ǹ� Resources���� ȸ�� �´� �ʹ��� �����ͼ� SushiManager �ڽ����� �ֱ�
            {
                // ���� : �÷��� �� ȸ�� ����� �޾ƿ� (ȸ�� ��ũ��Ʈ�� ��� ������ ��ȯ�ϴ� �Լ��� ���� ����. 
                //        other.gameObject.GetComponent<>() �� ����� �޾ƿ���, �� ����� ���ϴ� Sushi�� �Ѱ���� ��.
                //        �װ� ���� �ؿ� sushi.gameObject.GetComponent<>()��, Sushi���� ����� �Ű������� �ϴ� ������� �Լ��� �����. �� �Լ��� ����� �־ ȣ���ϸ��.
                //        �׷��� ������� sushi���� ����� �ݿ��� ������ ���� ��.
                

                //1. ���� ���� �ִ� FishRank�� �޾ƿ;���. Normal, Rare, SuperRare, Special 4������ ������.
                // Normal = 1000��, Rare = 1500��, SuperRare = 2000��, Special = 2500��
                switch (other.gameObject.GetComponent<RawFishForCutting>().FishTier)
                {
                    case "Normal":
                        AddSushiScore.currentSushiScore += 1000;
                        break;
                    case "Rare":
                        AddSushiScore.currentSushiScore += 1500;
                        break;
                    case "SuperRare":
                        AddSushiScore.currentSushiScore += 2000;
                        break;
                    case "Special":
                        AddSushiScore.currentSushiScore += 2500;
                        break;
                    default:
                        AddSushiScore.currentSushiScore += 5;
                        break;
                }
                GameObject sushi;

                Destroy(other.gameObject);

                switch (other.gameObject.name)
                {
                    // TODO : �����Ǵ� �ʹ��� ���� ������ ������ 

                    case "SalmonSashimi":
                        sushi = GameManager.Resource.Instantiate<GameObject>("SalmonSushi");
                        sushi.GetComponent<SushiScore>().sushiScore = AddSushiScore.currentSushiScore;
                        sushi.transform.parent = sushiManager.transform;
                        sushi.transform.position = rice.transform.position;
                        break;
                    case "ASashimi":
                        sushi = GameManager.Resource.Instantiate<GameObject>("ASushi");
                        sushi.GetComponent<SushiScore>().sushiScore = AddSushiScore.currentSushiScore;
                        sushi.transform.parent = sushiManager.transform;
                        sushi.transform.position = rice.transform.position;
                        break;
                    default:
                        break;
                }

                Destroy(rice);
            }
        }
    }
}