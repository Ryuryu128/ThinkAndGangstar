using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCycle : MonoBehaviour
{
    public Define.TileCylcle tcType = Define.TileCylcle.None;

    public int _firstNum;
    public string _symbol;
    public int _secondNum;
    public string _general = "=";
    public int _answer;

    public bool isCorrect;

    public TileInfo tileinfo;
    public QuizUITrigger trigger;

    public AudioClip audioCorrect;
    public AudioClip audioWrong;

    public bool[] isUpdated = new bool[4];

    private void Start()
    {
        tileinfo = new TileInfo();
        trigger = this.transform.GetChild(8).GetComponent<QuizUITrigger>();

        for (int i = 0; i < isUpdated.Length; i++)
        {
            isUpdated[i] = false;
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < isUpdated.Length; i++)
        {
            isUpdated[i] = false;
        }
    }

    public void TileCycleRoll()
    {

    }

    public TileInfo SetTA()
    {
        TileInfo TA = new TileInfo();
        TA.firstNum = _firstNum;
        TA.symbol = _symbol;
        TA.secondNum = _secondNum;
        TA.general = "=";
        TA.answer = _answer;

        return TA;
    }

    // ���� ���� �Լ�
    public void CheckAnswer(TileInfo tileinfo)
    {
        int comparement;
        tileinfo = SetTA();

        switch (_symbol)
        {
            case "+":
                comparement = ComparementSet(tileinfo, "+");
                break;
            case "-":
                comparement = ComparementSet(tileinfo, "-");
                break;
            case "��":
                comparement = ComparementSet(tileinfo, "*");
                break;
            case "��":
                comparement = ComparementSet(tileinfo, "/");
                break;
            default:
                comparement = -1;
                break;
        }

        if (comparement == tileinfo.answer)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audioCorrect);
            Debug.Log("answer is correct");
            isCorrect = true;
            //������ 30 ����
            Manager.Instance.PlusFeverGaugeValue();
            ChangeScore();
            ChangeStamina();
        }
        else
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audioWrong);
            Debug.Log("answer isn't correct");
            isCorrect = false;
            ChangeScore();
            ChangeStamina();
        }
        // ���� ���� �� ���� UI Off
        // trigger.tileCycle_UI.OffTileCycleUI();
        Manager.Instance._operator.SaveOperatorCount(_symbol);
    }

    public int ComparementSet(TileInfo tileinfo, string symbol)
    {
        int comparement;

        switch (symbol)
        {
            case "+":
                comparement = tileinfo.firstNum + tileinfo.secondNum;
                return comparement;

            case "-":
                if (tileinfo.firstNum < tileinfo.secondNum)
                {
                    // comparement -1 ���� �������� ������ ���� ��ü�� �߸� �� ���
                    comparement = -1;
                    return comparement;
                }
                comparement = tileinfo.firstNum - tileinfo.secondNum;
                return comparement;

            case "*":
                comparement = tileinfo.firstNum * tileinfo.secondNum;
                return comparement;

            case "��":
                if (tileinfo.firstNum < tileinfo.secondNum)
                {
                    // comparement -1 ���� �������� ������ ���� ��ü�� �߸� �� ���
                    comparement = -1;
                    return comparement;
                }
                if (!(tileinfo.firstNum % tileinfo.secondNum == 0))
                {
                    // comparement -1 ���� �������� ������ ���� ��ü�� �߸� �� ���
                    comparement = -1;
                    return comparement;
                }

                comparement = tileinfo.firstNum / tileinfo.secondNum;
                return comparement;
            default:
                return -1;
        }
    }

    // �����信 ���� ����,���¹̳� ó��
    public void ChangeScore()
    {
        int getScore;
        if (isCorrect) getScore = Random.Range(45, 56);
        else getScore = Random.Range(15, 26);

        Manager.currentScore += getScore;
    }

    public void ChangeStamina()
    {
        if (!isCorrect)
            Manager.currentStamina -= 1;
    }



}
