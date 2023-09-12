using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace AHN
{
    public class MakeSushi : MonoBehaviour
    {
        [SerializeField] GameObject rice;
        [SerializeField] GameObject sushi;
        [SerializeField] GameObject rawFish;
        [SerializeField] GameObject wasabi;
        [SerializeField] Transform riceSocketTransform;    // ��� ȸ�� �󸶳� ������������� ������ ��

        bool canScroeUp = true;
        bool oneButton = false;
        bool twoButton = false;
        bool threeButton = false;
        int currentScore = 0;   // ������ϱ� ���� ����. ���� ����

        XRBaseController xrController;

        private void Start()
        {
            xrController = GameObject.FindObjectOfType<XRBaseController>(true);
            sushi.SetActive(false);
        }

        private void OnEnable()
        {
            StartCoroutine(LocatedRiceAndSushiSameTransformRoutine());      // �ʹ�� ���� ��ġ�� �׻� ���� �ֵ���
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

        IEnumerator LocatedRiceAndSushiSameTransformRoutine()
        {
            while (true)
            {
                if (Vector3.Distance(rawFish.transform.position, riceSocketTransform.position) < 0.5f)    // ȸ�� ���� ��ġ�� ��������ٸ�,
                {
                    FinishSushi();
                }

                sushi.transform.position = rice.transform.position;
                yield return null;
            }
        }

        void FinishSushi()
        {
            // �� �ڽ����� �ִ� Socket Transform�� ȸ�� ��ġ�� ��������� ��, �ͻ��, ȸ�� ��Ȱ��ȭ�ϰ� �ʹ��� Ȱ��ȭ ��Ų��.
            sushi.SetActive(true);      // ���⼭ �ϼ��� ���õ��� Resources ������ �� �ְ� ȸ�� ���� ȸ�� �´� sushi�� Resources���� ��������?
            wasabi.SetActive(false);
            rawFish.SetActive(false);
            rice.SetActive(false);
        }
    }
}