using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class OrderSheet : MonoBehaviour
    {
        public TextMesh menuText;     // ���������� ���� �޴�

        // TODO : ���̺� ��ȣ�� ����� ��. �̰� �մ��� mySeat�� ��. �װŸ� ���� ����

        public void MenuTextInput(string menu, int seatNumber)
        {
            // menuText.text = "�̹� ������ �޴��� ��, ���������� ���� �ϳ��� �޴�";
            menuText.text = $"{menu}\n{seatNumber}�� �¼�";
        }
    }
}
