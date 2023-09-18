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
        public List<GameObject> plateAndFood;

        private void Start()
        {
            plateAndFood = new List<GameObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 24)
            {
                plate = other.gameObject;
                other.gameObject.transform.position = transform.position;
                isPlate = true;
                other.GetComponent<XRGrabInteractable>().enabled = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                // TODO : ���� rotation�� z�� x�� freeze �ǵ���

                other.gameObject.GetComponentInChildren<BoxCollider>().isTrigger = false;
            }
            plateAndFood.Add(other.gameObject);
        }
        public bool IsPlate()
        {
            return isPlate;
        }

        public List<GameObject> PlateAndFood()
        {
            return plateAndFood;
        }
    }
}
