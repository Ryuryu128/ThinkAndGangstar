using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScene : BaseScene
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
        SceneType = Define.Scene.Main;

        // TODO
        // UIManager�� �̿��� UI ȣ��
    }

    public void MoveToMain()
    {
        ChangeScene(Define.Scene.Main);
    }
}
