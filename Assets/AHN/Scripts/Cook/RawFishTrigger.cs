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
                // if (other.gameObject.transform.p)
                
                Destroy(other.gameObject);
                GameObject sushi = GameManager.Resource.Instantiate<GameObject>("Sushi");
                sushi.transform.parent = sushiManager.transform;
                sushi.transform.position = rice.transform.position;
                Destroy(rice);
            }
        }
    }
}