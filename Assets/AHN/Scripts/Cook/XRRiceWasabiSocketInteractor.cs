using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

namespace AHN
{
    /// <summary>
    /// �信 �ͻ�� ���� Socket.
    /// + Material�� �ƿ� �������� ������.
    /// </summary>
    public class XRRiceWasabiSocketInteractor : XRSocketInteractor
    {
        protected override void CreateDefaultHoverMaterials()
        {
            base.CreateDefaultHoverMaterials();
            interactableHoverMeshMaterial = null;
            interactableCantHoverMeshMaterial = null;
        }
    }
}