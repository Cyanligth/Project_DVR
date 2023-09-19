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
    public float x = -0.01f;
    public float timer = 0;

    [SerializeField] private string fishTier;
    [SerializeField] private string fishName;
    public string FishTier { get { return fishTier; } set { fishTier = value; } }
    public string FishName { get { return fishName; } set { fishName = value; } }

    public bool firstHeadHit = false;

    Coroutine check;

    KinfeRay kinfeRay;

    GameObject fishPrefab;

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
                fishPrefab = GameManager.Resource.Instantiate<GameObject>("Jeon_Prefab/FishMeat", kinfeRay.hitInfoPos, Quaternion.identity);
                TakeFishInfo();
            }

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
    private void TakeFishInfo()
    {
        fishPrefab.GetComponent<RawSalmon>().FishTier = fishTier;
        fishPrefab.GetComponent<RawSalmon>().FishName = fishName;
    }

    public void CuttingFish()
    {
        if (!firstHeadHit)
            return;

        if (kinfeRay.collisionNormal.x <= x)
        {
            Debug.Log("�� ������");

            check = StartCoroutine(CheckSecondHitTime());
        }

    }

    public void TakePrefab()
    {
        if (timer < 5)
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
        else if (timer >= 5)
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
