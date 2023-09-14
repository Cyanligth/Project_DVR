using SerializableCallback;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace AHN
{
    public class TakeOutRice : MonoBehaviour
    {
        // RicePile�� ���� ������ Rice �� ����� �տ� ��������.
        [SerializeField] GameObject riceTransform;
        int riceCount;

        private void Start()
        {
            GameObject rice = GameManager.Resource.Instantiate<GameObject>("SushiManager");
            riceCount = 1;
            rice.gameObject.transform.position = riceTransform.transform.position;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == 20)
            {
                GameObject rice = GameManager.Resource.Instantiate<GameObject>("SushiManager");
                riceCount++;
                rice.gameObject.transform.position = riceTransform.transform.position;
            }
        }

    }
}