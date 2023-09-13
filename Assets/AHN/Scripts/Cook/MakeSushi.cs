using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace AHN
{
    public class MakeSushi : MonoBehaviour
    {
        [SerializeField] GameObject rice;
        bool canScroeUp = true;
        bool oneButton = false;
        bool twoButton = false;
        bool threeButton = false;
        int currentScore = 0;   // ������ϱ� ���� ����. ���� ����

        XRBaseController xrController;

        private void Start()
        {
            xrController = GameObject.FindObjectOfType<XRBaseController>(true);
        }

        private void OnEnable()
        {
            rice.SetActive(true);
        }

        /// <summary>
        /// ���� ��� ��Ʈ�ѷ� ��ư�� �������� ������ ���� + ����. ������ ���� ������ 3��������.
        /// </summary>
        /// <param name="currentScore"></param>
        public void ScoreUP(ActivateEventArgs args)
        {
            if (threeButton)    // �� ���� �� ä������ �� �̻� ���� ���ø��� return
            {
                Debug.Log(currentScore);
                ActivateHaptic(args);
                return;
            }
            else if (twoButton)     // �� ��° Ŭ��
            {
                threeButton = true;
                currentScore += 500;
                twoButton = false;                 // canScoreUp = false, oneButton = false, twoButton = false, threeButton = true;
                ActivateHaptic(args);
                Debug.Log(currentScore);
            }
            else if (oneButton)     // �� ��° Ŭ��
            {
                twoButton = true;
                currentScore += 500;
                oneButton = false;                 // canScoreUp = false, oneButton = false, twoButton = true, threeButton = false;
                ActivateHaptic(args);
                Debug.Log(currentScore);
            }
            if (canScroeUp)     // ù ��° Ŭ��
            {
                oneButton = true;
                currentScore += 500;
                canScroeUp = false;                 // canScoreUp = false, oneButton = true, twoButton = false, threeButton = false;
                ActivateHaptic(args);
                Debug.Log(currentScore);
            }
        }

        void ActivateHaptic(ActivateEventArgs args)
        {
            XRBaseControllerInteractor interactor = args.interactorObject.transform.GetComponent<XRBaseControllerInteractor>();
            if (interactor != null)
            {
                interactor.SendHapticImpulse(0.3f, 0.1f);
            }
        }
    }
}
