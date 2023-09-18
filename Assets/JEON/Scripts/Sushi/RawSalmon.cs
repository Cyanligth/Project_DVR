using KIM;
using System.Collections.Generic;
using UnityEngine;
// 2��° �и�
public class RawSalmon : MonoBehaviour
{
    float cuttingCount;

    GameObject knife;

    Material baseColor;
    MeshRenderer meshRenderer;

    public List<GameObject> fishMeats;
    private string fishTier;

    public string FishTier { get { return fishTier; } set { fishTier = value; } }

    private void Awake()
    {
        knife = GameObject.Find("Knife");
        meshRenderer = GetComponent<MeshRenderer>();

        baseColor = meshRenderer.material;
        meshRenderer.material = baseColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 25)
        {
            Debug.Log("����");
            cuttingCount++;
            if (cuttingCount >= 5)
            {
                Debug.Log("��");

                foreach (GameObject salmon in fishMeats)
                {
                    salmon.SetActive(true);
                    salmon.transform.SetParent(null);
                    salmon.GetComponent<RawFishForCutting>().FishTier = fishTier;
                }
                gameObject.SetActive(false);
            }
        }

    }
}
