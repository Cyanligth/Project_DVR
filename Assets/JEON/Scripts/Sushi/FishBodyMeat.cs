using Jeon;
using KIM;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// 1��° �и�
public class FishBodyMeat : MonoBehaviour
{
    // TODO : �и��Ǵ� �κ� �����ͼ� ��ũ��Ʈ �и��ϱ�
    public float x = -0.15f;
    public float timer = 0;

    private string fishTier;

    public string FishTier { get { return fishTier; } set { fishTier = value; } }

    public bool firstHeadHit = false;

    Coroutine check;

    KinfeRay kinfeRay;

    private void Awake()
    {
        kinfeRay = GameObject.Find("KnifeRayCast").GetComponent<KinfeRay>();
    }
    public void ChackTimer()
    {
        Debug.Log("��������");

        if (timer < 2)
        {
            Debug.Log("�����հ�����");

            for (int i = 0; i < 2; i++)
            {
                GameManager.Resource.Instantiate<GameObject>("Jeon_Prefab/FishMeat", kinfeRay.hitInfoPos, Quaternion.identity).GetComponent<RawSalmon>().FishTier = fishTier;
            }
            Debug.Log($"{kinfeRay.fish.transform.parent.name}");

            Destroy(kinfeRay.fish.transform.parent.gameObject);

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

    public void CuttingFish()
    {
        if (!firstHeadHit)
            return;

        if (kinfeRay.collisionNormal.x < x)
        {
            Debug.Log("�� ������");

            check = StartCoroutine(CheckSecondHitTime());
        }

    }

    public void TakePrefab()
    {
        if (timer < 2)
        {
            Debug.Log("�����հ�����");

            for (int i = 0; i < 2; i++)
            {
                GameManager.Resource.Instantiate<GameObject>("Jeon_Prefab/FishMeat", kinfeRay.hitInfoPos, Quaternion.identity);
            }
            Debug.Log($"{kinfeRay.fish.transform.parent.name}");

            Destroy(kinfeRay.fish.transform.parent.gameObject);

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
