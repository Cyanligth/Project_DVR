using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace AHN
{
    public class ChangeRiceWithWasabi : MonoBehaviour
    {
        [SerializeField] GameObject wasabi;

        private void Start()
        {
            gameObject.SetActive(true);
            wasabi.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 22)    // �ͻ��(22)�� Ʈ���� �ƴٸ�, �ͻ�� �̹� �߶��� ������ ��ü
            {
                // TODO : �ͻ�� ��Ȱ��ȭ �Ǵ� �� �ƴ϶� Destroy �ž���
                other.gameObject.SetActive(false);
                wasabi.SetActive(true);
            }
        }
    }
}