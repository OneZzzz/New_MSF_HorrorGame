using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem_GetBase : InteractionItemBase
{
    public ItemData data;
    public string itemName;
    public override void Start()
    {
        base.Start();
        if (StateUIManager.instance.GetState(itemName))
            gameObject.SetActive(false);
    }

    public override void End()
    {
        base.End();
        InventorySystem.instance.Add(data);
        StateUIManager.instance.SetState(itemName, true);
        Destroy(gameObject);
    }
}
