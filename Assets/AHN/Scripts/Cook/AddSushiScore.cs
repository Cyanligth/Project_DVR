using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSushiScore : MonoBehaviour
{
    // SushiManager�� �信 ���� score.
    // �信�� ���� ������ += �ϰ�, fish���� +=�ϰ�, ������ �ʹ��� ����� �� �� �� �ʹ信�� ���� ������ �Ѱ���
    public static int currentSushiScore;

    private void OnEnable()
    {
        currentSushiScore = 0;
    }
}
