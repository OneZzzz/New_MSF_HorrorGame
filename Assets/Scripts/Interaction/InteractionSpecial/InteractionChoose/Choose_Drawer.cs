using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Drawer : InteractionChooseBase
{

    private InteractionBase interaction;
    public ItemData data;
    private void Start()
    {
        interaction = transform.GetChild(0).GetComponent<InteractionBase>();
        if (StateUIManager.instance.GetState("matchstick"))
            gameObject.SetActive(false);
    }



    public override void Option1()
    {
        player.enabled = true;
        this.enabled = false;
        InventorySystem.instance.Add(data);
        StateUIManager.instance.SetState("matchstick", true);
        interaction.OnPlayerInteraction(player);
    }
    public override void Option2()
    {
        player.enabled = true;
    }
}
