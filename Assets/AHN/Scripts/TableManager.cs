using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AHN
{
    public class TableManager : MonoBehaviour
    {
        // Seat[] �� ���� �¼����� ������.
        // TODO : �����̸� customer�� ���̻� �������� ���ϵ���. Bool ��ȯ������ ���̺��� ���������ƴ����� �˷��ִ� �Լ��� ����� �̰� �̺�Ʈ�� �־��.
        // �׸��� �մ��� ������ �� �� �Լ��� ȣ����Ѽ� true�� �մ� ���� ����!


        // seat�� Vector3 (�մ԰� seat�� �Ÿ���) < 1f �̶�� �¼��� á�ٴ� ��.
        // seat �� ��ųʸ��� �����ؼ� seat1 empty, seat2 full �̷������� empty, full�� value��, seat[n]�� key��
        // Dictionary(key, value) �� Dictionary(seat[n], stirng) ���� �ؼ� ����.


        [SerializeField] SerializedDictionary<int, string> SeatDic;
    }
}