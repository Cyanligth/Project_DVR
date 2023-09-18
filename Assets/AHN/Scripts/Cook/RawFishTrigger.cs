using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class RawFishTrigger : MonoBehaviour
    {
        [SerializeField] GameObject sushiManager;
        [SerializeField] GameObject rice;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 21)   // ȸ�� trigger�Ǹ� Resources���� ȸ�� �´� �ʹ��� �����ͼ� SushiManager �ڽ����� �ֱ�
            {
                // TODO : ȸ�� trigger �Ǹ�, �׸��� ȸ�� ����� ���� ����� ���ٸ� �� ����� ����.
                // TODO : ȸ�� �´� �ʹ����� �ٲ� �� �־����. "Sushi" �κ��� ������ �����ҵ�. Switch case ������
                // TODO : �÷��� �� ȸ�� ����� �޾ƿ� (ȸ�� ��ũ��Ʈ�� ��� ������ ��ȯ�ϴ� �Լ��� ���� ����. 
                //        other.gameObject.GetComponent<>() �� ����� �޾ƿ���, �� ����� ���ϴ� Sushi�� �Ѱ���� ��.
                //        �װ� ���� �ؿ� sushi.gameObject.GetComponent<>()��, Sushi���� ����� �Ű������� �ϴ� ������� �Լ��� �����. �� �Լ��� ����� �־ ȣ���ϸ��.
                //        �׷��� ������� sushi���� ����� �ݿ��� ������ ���� ��.
                
                Destroy(other.gameObject);
                GameObject sushi = GameManager.Resource.Instantiate<GameObject>("Sushi");
                sushi.transform.parent = sushiManager.transform;
                sushi.transform.position = rice.transform.position;
                Destroy(rice);
            }
        }
    }
}