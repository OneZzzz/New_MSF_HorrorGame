using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributionBoxController : MonoBehaviour
{
    private List<DistributionItemButton> items = new List<DistributionItemButton>();
    private Transform itemsParent;
    private GameObject game;
    private PlayerController player;

    private void Start()
    {
        itemsParent = transform.GetChild(0).GetChild(0);
        game = transform.GetChild(0).gameObject;
        GetItem();
    }
    private void GetItem()
    {
        for (int i = 0; i < itemsParent.childCount; i++)
        {
            DistributionItemButton item= itemsParent.GetChild(i).GetComponent<DistributionItemButton>();
            items.Add(item);
            item.GetController(this);
            item.Renew();
        }
    }
    public bool GetResult()
    {
        int number = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].index != 0)
                number++;
        }
        if (number != 0)
            return false;
        else
            return true;
    }
    public void CheckResult()
    {
        if(GameSave.instance.switchState.ContainsKey("distribution"))
        {
            GameSave.instance.switchState["distribution"] = GetResult();
        }
        else
        {
            GameSave.instance.switchState.Add("distribution", GetResult());
        }
    }
    private void Update()
    {
        CheckResult();
    }
    public void Close()
    {
        game.SetActive(false);
        player.enabled = true;
    }
    public void Open(PlayerController player)
    {
        this.player = player;
        player.enabled = false;
        game.SetActive(true);
    }
}
