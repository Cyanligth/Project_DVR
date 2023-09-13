using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class KinfeRay : MonoBehaviour
{
    public LayerMask mask;
    public RaycastHit hitInfo;
    public float maxDistance = 10f;

    bool firstHeadHit = false;

    float x = -1f;
    Vector3 collisionNormal;
    Vector3 hitInfoPos;
    GameObject fish;

    float timer = 0;
    Coroutine check;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);

        // ���̰� Ư�����̾� ������Ʈ�� ���������
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, maxDistance, mask))
        {
            firstHeadHit = true;
            collisionNormal = hitInfo.normal;
            hitInfoPos = hitInfo.transform.position;
            fish = hitInfo.collider.gameObject;
            Debug.Log($"{collisionNormal}");
        }
        else
        {
            firstHeadHit = false;       // ���̾ Ư�����̾� ������Ʈ�� ������� ������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ������Ʈ�� ���̾ 29���̰�, Ʈ����¶��
        if (other.gameObject.layer == 29 && firstHeadHit && collisionNormal.x < x)
        {

            Debug.Log("Ʈ���� �ƴ�");
            Debug.Log($"{collisionNormal.x < x}");
            CuttingFish();
        }
    }

    public void CuttingFish()
    {
        if (!firstHeadHit)
            return;

        if (collisionNormal.x < x)
        {
            Debug.Log("�� ������");
            check = StartCoroutine(CheckSecondHitTime());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.layer == 29) && !firstHeadHit && collisionNormal.x < x)
        {
            Debug.Log("��������");

            if (timer < 2)
            {
                Debug.Log("�����հ�����");
                for (int i = 0; i < 2; i++)
                {
                    GameManager.Resource.Instantiate<GameObject>("Jeon_Prefab/FishMeat", hitInfoPos, Quaternion.identity);
                }
                Debug.Log($"{fish.transform.parent.name}");
                Destroy(fish.transform.parent.gameObject);

                StopCoroutine(check);
                timer = 0;
            }
            else if (timer >= 2)
            {
                Debug.Log("�ٽ��߶�");
                timer = 0;
                StopCoroutine(check);
            }
        }
    }

    IEnumerator CheckSecondHitTime()
    {
        Debug.Log("2�ʾȿ� �ڸ���");
        while (true)
        {
            timer += Time.deltaTime;
            Debug.Log($"{timer}");
            yield return null;
        }
    }
}
