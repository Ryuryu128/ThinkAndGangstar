using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchivementMessage : MonoBehaviour
{
    void Start()
    {
        if (Manager.isAnyAchived)
            gameObject.GetComponent<TextMeshProUGUI>().text = "���������� �޼��߾�!\n�������� ����� Ȯ���غ���";
        else
            gameObject.GetComponent<TextMeshProUGUI>().text = "�������� ��\n���� �� ���� �ž�!����!";
    }
}
