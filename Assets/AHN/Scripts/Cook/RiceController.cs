using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace AHN
{
    public class RiceController : MonoBehaviour
    {
        [SerializeField] GameObject rice;
        [SerializeField] GameObject riceMeshRenderer;
        bool canScroeUp = true;
        bool oneButton = false;
        bool twoButton = false;
        bool threeButton = false;

        XRBaseController xrController;

        private void Start()
        {
            xrController = GameObject.FindObjectOfType<XRBaseController>(true);
        }

        /// <summary>
        /// ���� ��� ��Ʈ�ѷ� ��ư�� �������� ������ ���� + ����. ������ ���� ������ 3��������.
        /// </summary>
        /// <param name="currentScore"></param>
        public void ScoreUP(ActivateEventArgs args)
        {
            if (threeButton)    // �� ���� �� ä������ �� �̻� ���� ���ø��� return
            {
                ActivateHaptic(args);
                return;
            }
            else if (twoButton)     // �� ��° Ŭ��
            {
                riceMeshRenderer.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
                threeButton = true;
                AddSushiScore.currentSushiScore += 200;
                twoButton = false;                 // canScoreUp = false, oneButton = false, twoButton = false, threeButton = true;
                ActivateHaptic(args);
            }
            else if (oneButton)     // �� ��° Ŭ��
            {
                riceMeshRenderer.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
                twoButton = true;
                AddSushiScore.currentSushiScore += 200;
                oneButton = false;                 // canScoreUp = false, oneButton = false, twoButton = true, threeButton = false;
                ActivateHaptic(args);
            }
            if (canScroeUp)     // ù ��° Ŭ��
            {
                riceMeshRenderer.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
                oneButton = true;
                AddSushiScore.currentSushiScore += 200;
                canScroeUp = false;                 // canScoreUp = false, oneButton = true, twoButton = false, threeButton = false;
                ActivateHaptic(args);
            }
        }

        public int AddScore(int sushiScore)
        {
            return sushiScore; 
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
