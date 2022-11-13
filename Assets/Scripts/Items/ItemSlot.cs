using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public GameObject iconObj;
    public Image icon;
    public string nameTxt;
    public string descTxt;

    public void AddItem(InventoryItem newItem)
    {
        iconObj.SetActive(true);
        nameTxt = newItem.data.displayName;
        descTxt = newItem.data.description;
        icon.sprite = newItem.data.icon;
        // Debug.Log("add " + newItem.data.displayName);
    }

    public void ClearSlot()
    {
        // if (item != null)
        // {
        //     Debug.Log("clear " + item.data.displayName);
        // }
        // else
        // {
        //     Debug.Log("clear ");
        // }
        nameTxt = "";
        descTxt = "";
        icon.sprite = null;
        icon.enabled = false;
        iconObj.SetActive(false);
    }
}
