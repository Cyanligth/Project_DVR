using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // Ű����ũ ��, ���̺� ��, ������ �� �� �� ��ġ�� �� ������Ʈ�� �־ �� ������Ʈ�� ���ؼ� �� �� �ֵ�����.
    // ex.Ű����ũ �տ� �������Ʈ �ϳ� �ּ� customer�� �� �������Ʈ�� ���ؼ� move�ϵ���.

    public Transform customersPos;
    public Transform customersDir;
    public Transform destination;
    public float speed;

    private void Awake()
    {
        customersPos.position = transform.position;
    }
}
