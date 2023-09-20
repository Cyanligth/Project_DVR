using Jeon;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class KinfeRay : MonoBehaviour
{
    public LayerMask mask;
    public RaycastHit hitInfo;
    public float maxDistance = 10f;

    public Vector3 collisionNormal;
    public Vector3 hitInfoPos;
    public GameObject fish;

    FishBodyMeat fishBodyMeat;

    private void Awake()
    {
        fishBodyMeat = null;
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);


        // ���̰� Ư�����̾� ������Ʈ�� ���������
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, maxDistance, mask))
        {
            fishBodyMeat = hitInfo.transform.GetComponent<FishBodyMeat>();
            fishBodyMeat.firstHeadHit = true;
            collisionNormal = hitInfo.normal;
            hitInfoPos = hitInfo.transform.position;
            fish = hitInfo.collider.gameObject;
            Debug.Log($"{collisionNormal}");
        }
        else
        {
            if (fishBodyMeat != null)
                fishBodyMeat.firstHeadHit = false;       // ���̾ Ư�����̾� ������Ʈ�� ������� ������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 v = collisionNormal - transform.forward;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        // ���� ������Ʈ�� ���̾ 29���̰�, Ʈ����¶��
        if (other.gameObject.layer == 29 && fishBodyMeat.firstHeadHit && angle > 70 && angle <120)
        {
            //Debug.Log("Ʈ���� �ƴ�");
            //Debug.Log($"{collisionNormal.x < fishBodyMeat.x}");

            fishBodyMeat.CuttingFish();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 v = collisionNormal - transform.forward;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        if ((other.gameObject.layer == 29) && !fishBodyMeat.firstHeadHit && angle > -210 && angle < -150)
        {
            Debug.Log("��������");

            fishBodyMeat.TakePrefab();
        }
    }
}
