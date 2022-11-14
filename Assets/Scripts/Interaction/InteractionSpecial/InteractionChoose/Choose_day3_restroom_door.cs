using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_day3_restroom_door : InteractionChooseBase
{
    public InteractionBase interaction;
    public GameObject closeDoor;

    public override void Option1()
    {
        if (GameSave.instance.switchState.ContainsKey("Wire"))
        {
            if (GameSave.instance.switchState["Wire"])
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
        gameObject.SetActive(false);
        this.enabled = false;
        closeDoor.SetActive(true);
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
