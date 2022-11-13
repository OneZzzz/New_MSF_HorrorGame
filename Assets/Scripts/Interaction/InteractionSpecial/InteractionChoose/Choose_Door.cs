using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Door : InteractionChooseBase
{


    public string NextSceneName;



    public override void Option1()
    {
        player.enabled = true;
        this.enabled = false;
        GameHalper.instance.ChangeScene(NextSceneName);

    }
    public override void Option2()
    {
        player.enabled = true;
    }
}
