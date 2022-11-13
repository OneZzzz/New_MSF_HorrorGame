using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_door : Trigger
{
    public string sceneName;
    public override void OnTriggerEnterEvent()
    {
        Debug.Log("door");
        GameHalper.instance.ChangeScene(sceneName);
        base.OnTriggerEnterEvent();
    }
}
