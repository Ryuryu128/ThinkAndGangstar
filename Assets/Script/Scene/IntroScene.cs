using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : BaseScene
{
    public override void Clear()
    {
        // TODO
        // Scene�� ����Ǿ��� �� Scene�� �����ִ� �κ�
    }

    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Intro;

        StartCoroutine("MoveToMain", 3.0f);
        // TODO
        // UIManager�� �̿��� UI ȣ��
    }

    IEnumerator MoveToMain(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ChangeScene(Define.Scene.Main);
    }
}
