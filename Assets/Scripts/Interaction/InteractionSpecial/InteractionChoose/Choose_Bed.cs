using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Bed : InteractionChooseBase
{
    public string NextSceneName;
    public int dayIndex;
    public InteractionItemBase interaction;

    public override void Option1()
    {
        player.enabled = true;
        if (GameSave.instance.day[dayIndex])
        {
            GameHalper.instance.ChangeScene(NextSceneName);
        }
        else
        {
            interaction.OnPlayerInteraction(player);
        }

    }
    public override void Option2()
    {
        player.enabled = true;
    }
}
