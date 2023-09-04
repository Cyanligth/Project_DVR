using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace KIM
{
    public class Fish : MonoBehaviour, IHittable
    {
        List<string> fishInfo;

        [SerializeField]
        protected FishData data;
        protected int curHp;
        protected float curLength;
        protected float curWeight;
        protected Vector3 moveDir;
        protected Rigidbody rb;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            SetHP();
            SetLength();
            SetWeight();
        }

        protected Vector3 GetRandVector()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f));
        }
        
        protected bool WallDetect()
        {
            // ���� �����ϸ� true ������ false
            return (Physics.OverlapSphere(this.transform.position, data.WallRecognitionRange, 1 << 14).Length >0);
        }
        
        protected void ChangeMoveDir()
        {
            Ray ray = new Ray();
            ray.origin = this.transform.position;
            ray.direction = this.transform.forward;
            RaycastHit hit;
            // ǥ������ �����ɽ�Ʈ�� ���� RaycastHit�� ���Ѵ�
            Physics.Raycast(ray, out hit, data.WallRecognitionRange, 1 << 14);

            // �� ǥ���� �븻���Ϳ� ��������� �����ʳ븻���͸� �����Ͽ�
            // ���� ����� ������, ������ �������� ����
            //moveDir = Vector3.Dot(hit.normal, transform.right) >= 0 ?
            //    transform.right / 2 : -transform.right / 2;

            // �� ǥ���� �븻���Ϳ� ��������� ���� ���͸� �����Ͽ�
            // ���� ����� ��, ������ �Ʒ��� ����
            //moveDir += Vector3.Dot(hit.normal, transform.up) >= 0 ?
            //    transform.up / 2 : -transform.up / 2;

            moveDir = -moveDir;
        }

        // �ִϸ��̼� ����, ������ ���߰�, grabinteractable Ű��
        protected void Die()
        {

        }
        public void Hit()
        {
            curHp--;
        }

        private void SetHP()
        {
            curHp = data.HP;
        }
        private void SetLength()
        {
            float randomRangeValue = data.Length / 10 + data.Length % 10;
            curLength = data.Length + Random.Range(-randomRangeValue,randomRangeValue);
        }
        private void SetWeight()
        {
            float randomRangeValue = data.Weight / 10 + data.Weight % 10;
            curWeight = data.Weight;
        }
        private void SetFishInfo()
        {
            fishInfo.Add(data.Name);
            fishInfo.Add(curWeight.ToString());
            fishInfo.Add(curLength.ToString());
            //enum
            fishInfo.Add(data.curFishType.ToString());
            //enum
            fishInfo.Add(data.curFishRank.ToString());
        }
    }
}
