using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_day3_dorm_restroom : InteractionChooseBase
{
    public string NextSceneName;
    public InteractionBase interaction;



    public override void Option1()
    {
        if (GameSave.instance.switchState.ContainsKey("tollet"))
        {
            if (GameSave.instance.switchState["tollet"])
            {
                ResultTrue();
                return;
            }
        }
        ResultFalse();
    }
    private void ResultTrue()
    {
        player.enabled = true;
        this.enabled = false;
        GameHalper.instance.ChangeScene(NextSceneName);
    }
    private void ResultFalse()
    {
        interaction.OnPlayerInteraction(player);
    }
    public override void Option2()
    {
        player.enabled = true;
    }
}
