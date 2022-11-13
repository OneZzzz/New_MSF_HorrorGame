using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItemBase : InteractionDefult
{
    public override void Start()
    {
        cursorType = CursorType.find;
    }

    public override void MouseEnterEvent()
    {
        GameManager.instance.SetInteractionTarget(this, cursorType);
    }
}
