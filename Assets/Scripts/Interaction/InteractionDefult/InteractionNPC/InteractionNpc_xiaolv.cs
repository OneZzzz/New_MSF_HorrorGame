using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNpc_xiaolv : InteractionNpcBase
{
    public string NextSceneName = "bathroom";
    public override void End()
    {
        InteractionUIManager.instance.CloseMessage();
        GameHalper.instance.Fade(false, 2, EnterNextScene, 0.5f, 0.2f);

    }
    private void EnterNextScene()
    {
        GameHalper.instance.ChangeScene(NextSceneName);
    }
}
