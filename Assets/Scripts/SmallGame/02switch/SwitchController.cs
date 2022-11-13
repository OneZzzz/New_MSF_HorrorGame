using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private List<GameObject> lights = new List<GameObject>();
    private List<GameObject> switch_open = new List<GameObject>();
    private List<GameObject> switch_close = new List<GameObject>();
    private Transform lightParents, openParents, closeParents,buttonParents;


    [HideInInspector]
    public bool total, gate, hall, tollet, hotwater, dorm;
    [HideInInspector]
    public bool haveDis, haveNumber;

    private PlayerController player;

    private void Start()
    {
        lightParents = transform.GetChild(0).GetChild(0).GetChild(0);
        openParents = transform.GetChild(0).GetChild(0).GetChild(2);
        closeParents = transform.GetChild(0).GetChild(0).GetChild(1);
        buttonParents = transform.GetChild(0).GetChild(0).GetChild(3);
        AddGo(lightParents, lights);
        AddGo(openParents, switch_open);
        AddGo(closeParents, switch_close);
        for (int i = 0; i < buttonParents.childCount; i++)
        {
            buttonParents.GetChild(i).GetComponent<SwitchItemButton>().SetSwitch(this);
        }

    }
    public void ShowSwitch()
    {
        GetDistribution();
        ShowSwitchState();
        ShowLight();

    }
    private void GetDistribution()
    {
        if (GameSave.instance.switchState.ContainsKey("distribution"))
        {
            haveDis = GameSave.instance.switchState["distribution"];
        }
        else
        {
            haveDis = false;
        }
    }

    public void SetSwitch(string name)
    {
        switch (name)
        {
            case "total":
                total = !total;
                break;
            case "gate":
                gate = !gate;
                break;
            case "hall":
                hall = !hall;
                break;
            case "tollet":
                tollet = !tollet;
                break;
            case "hotwater":
                hotwater = !hotwater;
                break;
            case "dorm":
                dorm = !dorm;
                break;
        }
        ShowSwitch();
    }


    private void ShowLight()
    {
        foreach (var item in lights)
        {
            item.gameObject.SetActive(false);
        }
        haveNumber = GetNumber();
        if (haveDis && haveNumber && total)
        {
            SetObject(lights, "total", total);
            SetObject(lights, "gate", gate);
            SetObject(lights, "hall", hall);
            SetObject(lights, "tollet", tollet);
            SetObject(lights, "hotwater", hotwater);
            SetObject(lights, "dorm", dorm);
        }
    }
    private bool GetNumber()
    {
        int number = 0;
        if (gate) number += 97;
        if (hall) number += 75;
        if (tollet) number += 46;
        if (hotwater) number += 126;
        if (dorm) number += 48;
        if (number == 220) return true;
        return false;
    }

    private void ShowSwitchState()
    {
        SetObject(switch_open, "total", total);
        SetObject(switch_open, "gate", gate);
        SetObject(switch_open, "hall", hall);
        SetObject(switch_open, "tollet", tollet);
        SetObject(switch_open, "hotwater", hotwater);
        SetObject(switch_open, "dorm", dorm);
        SetObject(switch_close, "total", !total);
        SetObject(switch_close, "gate", !gate);
        SetObject(switch_close, "hall", !hall);
        SetObject(switch_close, "tollet", !tollet);
        SetObject(switch_close, "hotwater",!hotwater);
        SetObject(switch_close, "dorm", !dorm);
    }

    public void OpenSwitch(PlayerController player)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        this.player = player;
        player.enabled = false;
        ShowSwitch();
    }
    public void CloseSwitch()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        player.enabled = true;
    }

    private void SaveSwitch()
    {
        if (!GameSave.instance.switchState.ContainsKey("total"))
            GameSave.instance.switchState.Add("total", false);
        if (!GameSave.instance.switchState.ContainsKey("gate"))
            GameSave.instance.switchState.Add("gate", false);
        if (!GameSave.instance.switchState.ContainsKey("hall"))
            GameSave.instance.switchState.Add("hall", false);
        if (!GameSave.instance.switchState.ContainsKey("tollet"))
            GameSave.instance.switchState.Add("tollet", false);
        if (!GameSave.instance.switchState.ContainsKey("hotwater"))
            GameSave.instance.switchState.Add("hotwater", false);
        if (!GameSave.instance.switchState.ContainsKey("dorm"))
            GameSave.instance.switchState.Add("dorm", false);

        GameSave.instance.switchState["total"]= (haveDis && haveNumber && total && total);
        GameSave.instance.switchState["gate"] = (haveDis && haveNumber && total && gate);
        GameSave.instance.switchState["hall"] = (haveDis && haveNumber && total && hall);
        GameSave.instance.switchState["tollet"] = (haveDis && haveNumber && total && tollet);
        GameSave.instance.switchState["hotwater"] = (haveDis && haveNumber && total && hotwater);
        GameSave.instance.switchState["dorm"] = (haveDis && haveNumber && total && dorm);
    }

    private void AddGo(Transform trans,List<GameObject> target)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            target.Add( trans.GetChild(i).gameObject);
        }
    }
    private GameObject GetObject(List<GameObject> objs,string name)
    {
        foreach (var item in objs)
        {
            if (item.name == name)
                return item;
        }
        return null;
    }
    private void SetObject(List<GameObject> objs, string name,bool state)
    {
        GetObject(objs, name).SetActive(state);
    }



    private void Update()
    {
        SaveSwitch();
    }
}
