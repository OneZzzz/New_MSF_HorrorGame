using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemData data { get; private set; }
    // public bool inInventory { get; private set; }

    public InventoryItem(ItemData data)
    {
        this.data = data;
    }

    // public void AddToInventory()
    // {
    //     inInventory = true;
    // }

    // public void RemoveFromInventory()
    // {
    //     inInventory = false;
    // }
}

