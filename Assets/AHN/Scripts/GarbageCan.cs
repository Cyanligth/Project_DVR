using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class GarbageCan : MonoBehaviour
    {
        [SerializeField] GameObject orderSheet;

        private void Start()
        {
            // orderSheet = GameManager.Resource.Load<GameObject>("OrderSheet");
            orderSheet = GameObject.FindObjectOfType<OrderSheet>().GetComponent<GameObject>();
        }

        // Sphere �ݶ��̴��� trigger �Ǵ� �ֹ����� Release Pool
        private void OnTriggerEnter(Collider other)
        {
            if (other == orderSheet)
            {
                GameManager.Pool.Release(other);
            }
        }
    }
}