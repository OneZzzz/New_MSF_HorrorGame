using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;
    private Dictionary<ItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public static InventorySystem FindInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }

        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<ItemData, InventoryItem>();
    }

    public void Add(ItemData data)
    {
        if (itemDictionary.TryGetValue(data, out InventoryItem value)) { }
        else
        {
            InventoryItem newItem = new InventoryItem(data);
            inventory.Add(newItem);
            itemDictionary.Add(data, newItem);
        }

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }

    public void Remove(ItemData data)
    {
        if (itemDictionary.TryGetValue(data, out InventoryItem value))
        {
            inventory.Remove(value);
            itemDictionary.Remove(data);

            if (OnItemChangedCallback != null)
            {
                OnItemChangedCallback.Invoke();
            }
        }
    }
}

