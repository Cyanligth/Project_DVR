using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDestroyOther : MonoBehaviour
{
    Vector3 resetPoint;

    private void OnTriggerEnter(Collider other)
    {
        resetPoint = new Vector3(0, 0, 0);
        Debug.Log($"���ӿ�����Ʈ�� ���̾�� {other.gameObject.layer}");

        if (other.gameObject.layer == 10 || other.gameObject.layer == 23)
        {
            Debug.Log(1);
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log(2);
            other.gameObject.transform.position = resetPoint;
        }
    }
}
