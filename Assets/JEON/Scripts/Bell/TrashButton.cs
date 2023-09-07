using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrashButton : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;
    public float resetSpeed = 5;
    public float followAngleTreshold;

    public Transform trashCoverTransform;
    public float openSpeed = 0.5f;
    public Rigidbody rb;

    private Vector3 initialLocalPos;
    Transform cover;
    Vector3 targetPoint;

    private Vector3 offset;
    private Transform pokeAttechTransform;

    private XRBaseInteractable interactable;

    private bool isFollowing = false;
    private bool freeze = false;
    private bool stopMoveCover;

    private void Start()
    {
        initialLocalPos = visualTarget.localPosition;
        cover = trashCoverTransform.transform;
        targetPoint = new Vector3(90, 0, 75);

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(ResetTarget);
        interactable.selectEntered.AddListener(Freeze);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor) // ��ȣ�ۿ��ϴ� ��ü�� XRPokeInteractor�� ��쿡�� ����
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;//XRPokeInteractor�� ����ȯ�Ͽ� ��ȣ�ۿ��ϴ� ��Ŀ�� ����� �����ɴϴ�.

            pokeAttechTransform = interactor.attachTransform; //pokeAttechTransform�� ��ȣ�ۿ��ϴ� ��Ŀ�� ����� ��ġ�� ȸ�� ������ �����մϴ�.

            // visualTarget�� ���� ��ġ�� pokeAttechTransform�� ��ġ ������ ����(������)�� ����մϴ�.
            // visualTarget�� ��Ŀ�� ����� ���󰡱� ���� ������� ��ġ�� ��Ÿ���ϴ�.
            offset = visualTarget.position - pokeAttechTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));
            if (pokeAngle < followAngleTreshold)
            {
                isFollowing = true; //��Ŀ�� ����� ���󰡴� ������ �����մϴ�.
                freeze = false;
            }
        }
    }

    public void ResetTarget(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            freeze = true;
            Coroutine at = StartCoroutine(OpenedCover());
        }
    }
    IEnumerator OpenedCover()
    {
        float zRot = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.005f);
            cover.rotation = Quaternion.Euler(0, 0, zRot);
            zRot -= 0.5f;
            if (zRot < -75)
                break;
        }

        yield return new WaitForSeconds(3f);
        while (true)
        {
            yield return new WaitForSeconds(0.005f);
            cover.rotation = Quaternion.Euler(0, 0, zRot);
            zRot += 0.5f;
            if (zRot > 0)
                break;
        }
    }

    /*public void OpenedCover()
    {
        Vector3 targetPosition = Vector3.Lerp(cover.position, targetPoint, 0.1f);

        cover.rotation = Quaternion.Euler(targetPosition);
        StartCoroutine(CloseCover());
    }

    IEnumerator CloseCover()
    {
        yield return new WaitForSeconds(3f);
        targetPoint = new Vector3(90, 0, 0);
        Vector3 targetPosition = Vector3.Lerp(cover.position, targetPoint, 0.1f);
        cover.rotation = Quaternion.Euler(targetPosition);
    }*/

    private void Update()
    {
        if (freeze)
            return;

        if (isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttechTransform.position + offset); // ��Ŀ�� ����� ��ġ�� ȸ���� visualTarget�� ���� ��ǥ��� ��ȯ�մϴ�.

            // localTargetPosition�� localAxis ���� �������� �������� �����մϴ�.
            // �̷��� ���� ���ʹ� normal �������θ� ��ġ�� ���� ��Ÿ���ϴ�.
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);

            // visualTarget�� ��ġ�� ��Ŀ�� ����� ��ġ�� offset�� ���� ������ �����մϴ�.
            // �̷ν� visualTarget�� �׻� ��Ŀ�� ����� ���󰡰� �˴ϴ�.
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, resetSpeed * Time.deltaTime);
        }
    }
}
