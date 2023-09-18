using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace AHN
{
    public class PlateRecognition : MonoBehaviour
    {
        // �� ������Ʈ�� collider�� Plate ���̾�(24)�� Ʈ���ŵǸ� ������ ��ġ�� �� �޶�ٵ��� (�� ��ġ�� �׳� �� ������Ʈ�� ��ġ��)

        public bool isPlate = false;
        public GameObject plate;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 24)
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                plate = other.gameObject;
                other.gameObject.transform.position = transform.position;
                isPlate = true;
                other.GetComponent<XRGrabInteractable>().enabled = false;
                rb.isKinematic = true;

                // TODO : ���� rotation�� z�� x�� freeze �ǵ���
                other.gameObject.GetComponentInChildren<BoxCollider>().isTrigger = false;
            }
        }

        public bool IsPlate()
        {
            return isPlate;
        }
    }
}
