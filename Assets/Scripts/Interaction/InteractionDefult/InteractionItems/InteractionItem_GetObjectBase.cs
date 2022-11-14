using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem_GetObjectBase : InteractionItemBase
{
    public ItemData data;
    public override void Start()
    {
        base.Start();
        if (GameSave.instance.items.ContainsKey(data.id))
        {
            gameObject.SetActive(false);
        }
    }

    public override void End()
    {
        base.End();
        InventorySystem.instance.Add(data);
        GameSave.instance.items.Add(data.id, true);
        Destroy(gameObject);
    }
}
