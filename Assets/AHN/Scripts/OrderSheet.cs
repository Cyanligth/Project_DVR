using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHN
{
    public class OrderSheet : MonoBehaviour
    {
        public TextMesh menuText;     // ���������� ���� �޴�

        public void MenuTextInput(string menu, int seatNumber)
        {
            menuText.text = $"{menu}\n{seatNumber}�� �¼�";
        }
    }
}
