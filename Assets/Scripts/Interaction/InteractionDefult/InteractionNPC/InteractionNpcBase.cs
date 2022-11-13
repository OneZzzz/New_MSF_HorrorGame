using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNpcBase : InteractionDefult
{
    public override void Start()
    {
        cursorType = CursorType.ellipsis;
    }

    public override void MouseEnterEvent()
    {
        GameManager.instance.SetInteractionTarget(this, cursorType);
    }
}
