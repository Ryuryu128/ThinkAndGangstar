using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override void Clear()
    {
        // TODO
        // Scene�� ����Ǿ��� �� Scene�� �����ִ� �κ�
    }

    private void Awake()
    {
        SceneType = Define.Scene.Game;
    }

    public void MoveToMain()
    {
        ChangeScene(Define.Scene.Main);
    }
}
