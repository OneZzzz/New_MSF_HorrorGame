using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionChooseBase : InteractionSpecial
{
    [TextArea]
    public string problem;
    public string option1, option2;

    public override void OnPlayerInteraction(PlayerController player)
    {
        this.player = player;
        if (player != null)
            player.enabled = false;
        InteractionUIManager.instance.ShowChoose(problem, option1, option2, Option1, Option2);
    }

    public virtual void Option1()
    {

        player.enabled = true;
    }
    public virtual void Option2()
    {
        print(5);
        player.enabled = true;
    }
    
}
