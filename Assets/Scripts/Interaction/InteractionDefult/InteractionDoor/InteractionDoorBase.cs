using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoorBase : InteractionDefult
{
    public override void Start()
    {
        cursorType = CursorType.opendoor;
    }
    public string sceneName;
    public override void InteractionEvent()
    {
        GameHalper.instance.ChangeScene(sceneName);
    }
    public override void MouseEnterEvent()
    {
        GameManager.instance.SetInteractionTarget(this, cursorType);
    }
}
