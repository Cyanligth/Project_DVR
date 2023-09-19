using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.XR.Interaction.Toolkit;

namespace AHN
{
    public class FoodRecognitionOnTable : MonoBehaviour
    {
        // �� ������Ʈ�� collider�� Plate ���̾�(24)�� Ʈ���ŵǸ� ������ ��ġ�� �� �޶�ٵ��� (�� ��ġ�� �׳� �� ������Ʈ�� ��ġ��)

        public bool isPlate = false;
        public List<GameObject> plateAndFood;

        private void Start()
        {
            plateAndFood = new List<GameObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 24)   // 24 : ����
            {
                GameObject plate = other.gameObject;
                other.gameObject.transform.position = transform.position;
                isPlate = true;
                other.GetComponent<XRGrabInteractable>().enabled = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.gameObject.GetComponentInChildren<BoxCollider>().isTrigger = false;
                plateAndFood.Add(other.gameObject);

            }
            else if (other.gameObject.layer == 23)  // �ʹ�
            {
                GameObject sushi = other.gameObject;
                plateAndFood.Add(other.gameObject);
            }
        }

        public bool IsPlate()   // ���̺� �տ� ���ð� �ִ��� ������
        {
            return isPlate;
        }

        public void IsPlateFalse()
        {
            isPlate = false;
        }

        public List<GameObject> PlateAndFood()
        {
            return plateAndFood;
        }
    }
}
