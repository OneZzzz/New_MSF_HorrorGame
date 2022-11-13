using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem_fire : InteractionItemBase
{
    public ItemData data;

    public override void End()
    {
        base.End();
        InventorySystem.instance.Add(data);
        StateUIManager.instance.SetState("KeroseneLamp", true);
        Destroy(gameObject);
    }
}
