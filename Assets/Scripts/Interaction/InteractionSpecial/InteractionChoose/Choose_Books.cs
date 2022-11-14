using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Books : InteractionChooseBase
{
    public GameObject door;

    private InteractionBase interaction;
    public ItemData data;
    private void Start()
    {
        interaction = transform.GetChild(0).GetComponent<InteractionBase>();
    }



    public override void Option1()
    {
        player.enabled = true;
        this.enabled = false;
        InventorySystem.instance.Add(data);
        StateUIManager.instance.SetState("diarypage", true);
        interaction.OnPlayerInteraction(player);
        door.transform.GetChild(0).gameObject.SetActive(false);
        door.transform.GetChild(1).gameObject.SetActive(true);
    }
    public override void Option2()
    {
        player.enabled = true;
    }
}
