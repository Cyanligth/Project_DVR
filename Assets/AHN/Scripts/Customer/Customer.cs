using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class Customer : MonoBehaviour
    {
        // Ű����ũ ��, ���̺� ��, ������ �� �� �� ��ġ�� �� ������Ʈ�� �־ �� ������Ʈ�� ���ؼ� �� �� �ֵ�����.
        // ex.Ű����ũ �տ� �������Ʈ �ϳ� �ּ� customer�� �� �������Ʈ�� ���ؼ� move�ϵ���.

        public Transform customersPos;
        public Transform customersDir;
        public Transform KioskDestination;
        public float speed;

        private void Awake()
        {
            customersPos.position = transform.position;
        }
    }
}