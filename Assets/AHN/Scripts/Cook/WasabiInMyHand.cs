using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class WasabiInMyHand : MonoBehaviour
    {
        // WasabiPile�� ���� ������ Wasabi�� ����� �տ� ��������.
        [SerializeField] GameObject wasabi;
        [SerializeField] GameObject wasabiTransform;

        private void Start()
        {
            wasabi = GameManager.Resource.Instantiate<GameObject>("Wasabi");
            wasabi.GetComponent<Rigidbody>().isKinematic = true;
            wasabi.gameObject.transform.position = wasabiTransform.transform.position;
        }
    }
}