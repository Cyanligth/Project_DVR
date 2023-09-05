using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bell : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;

    private Vector3 offset;
    private Transform pokeAttechTransform;

    private XRBaseInteractable interactable;

    private bool isFollowing = false;

    private void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
    }

    private void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;

            pokeAttechTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttechTransform.position;
        }
    }

    private void Update()
    {
        if (isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttechTransform.position + offset); // 
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis); // Vector3.Project �������� ������ ��� ���͸� ��ȯ�մϴ�. �̷��� ���� ���ʹ� normal�������θ� ��ġ�� ���� ��Ÿ���ϴ�.

            visualTarget.position = pokeAttechTransform.position + offset;
        }
    }

}
