using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIM
{
    public class KIM_FishTank : MonoBehaviour
    {
        private List<Dictionary<string, string>> fishList = new List<Dictionary<string, string>>();

        private void OnTriggerEnter(Collider other)
        {
            // ���� �浹�� ��ü�� ���̾ �ǽ��ڽ����
            if(other.gameObject.layer == 15)
            {
                Debug.Log("FishTankUpdated");
                other.gameObject.GetComponent<FishBox>().GetFishDicList();
            }
        }
    }
}