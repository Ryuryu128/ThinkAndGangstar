using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCycle_Manager : MonoBehaviour
{
    public TileCycle _tileCycle = new TileCycle();
    

    void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        Init();
    }

    // �ʱ�ȭ �Լ�
    void Init()
    {
        _tileCycle.tcType = SetTileCycleType();

        switch (_tileCycle.tcType)
        {
            case Define.TileCylcle.AnswerFixed:
                SetAnswerFixed();
                break;
            case Define.TileCylcle.SymbolFixed:
                SetSymbolFixed();
                break;
        }
        _tileCycle._general = "=";
        /*
        // ������ �� �ùķ��̼�
        _tileCycle._firstNum = 1;
        _tileCycle._secondNum = 1;
        _tileCycle._answer = 2;

        _tileCycle.tileinfo = _tileCycle.SetTA();
        _tileCycle.CheckAnswer(_tileCycle.tileinfo);

        // �ӽ� �� ����
        _tileCycle.ChangeScore(ref score);
        _tileCycle.ChangeStamina(ref stamina);

        Debug.Log($"stamina: {stamina}, score: {score}");

        // ������ �� �ùķ��̼�
        _tileCycle._firstNum = 1;
        _tileCycle._secondNum = 1;
        _tileCycle._answer = 3;

        _tileCycle.tileinfo = _tileCycle.SetTA();
        _tileCycle.CheckAnswer(_tileCycle.tileinfo);

        // �ӽ� �� ����
        _tileCycle.ChangeScore(ref score);
        _tileCycle.ChangeStamina(ref stamina);

        Debug.Log($"stamina: {stamina}, score: {score}");
        */
    }

    // Ÿ�ϻ���Ŭ ���� ���� ���� �Լ�
    Define.TileCylcle SetTileCycleType()
    {
        Define.TileCylcle randTC;

        if (this.tag.Equals("AnswerFixed"))
            randTC = Define.TileCylcle.AnswerFixed;
        else if(this.tag.Equals("SymbolFixed"))
            randTC = Define.TileCylcle.SymbolFixed;
        else
        {
            Debug.Log("Can't set TileCycle Type!");
            randTC = Define.TileCylcle.None;
        }

        return randTC;
    }


    // ������� Ÿ�ϻ���Ŭ ���� �Լ�
    void SetAnswerFixed()
    {
        // ������ ���� �� random ���� �� ����
        _tileCycle._answer = SetRandAnswer();
        Debug.Log($"Fixed Answer Value is {_tileCycle._answer}");
    }

    // ��ȣ���� Ÿ�ϻ���Ŭ ���� �Լ�
    void SetSymbolFixed()
    {
        // ������ ��ȣ �� random ���� �� ����
        _tileCycle._symbol = SetRandSymbol();
        Debug.Log($"Fixed Symbol Value is {_tileCycle._symbol}");
    }


    public int SetRandAnswer()
    {
        // 1~20 ���� ���� ���� �� �ϳ��� answer ����
        // �׽�Ʈ�ϸ鼭 Ȯ�� �����ؾ��� ��
        int rand = Random.Range(3, 16); // ���� ����
        if(rand == 13 || rand == 17 || rand == 19) // �Ҽ� ���� ����
        {
            rand -= 1;
        }
        int answer = rand;
        return answer;
    }

    public string SetRandSymbol()
    {
        // 1~9 ���� ���� ���� �� �ϳ��� answer ����
        // �׽�Ʈ�ϸ鼭 Ȯ�� �����ؾ��� ��

        // ���� ���� ���� ������ 2:2:1:1�� ���� ����
        int rand = Random.Range(0,6);

        if (rand >= 0 && rand < 2)
            return "+";
        else if (rand >= 2 && rand < 4)
            return "-";
        else if (rand >= 4 && rand < 5)
            return "��";
        else
            return "��";
    }
}
