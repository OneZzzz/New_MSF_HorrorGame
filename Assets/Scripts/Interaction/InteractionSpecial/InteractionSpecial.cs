using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSpecial : InteractionBase
{
    public virtual void OnMouseEnter()
    {
        if (this.enabled && CursorManager.instance.GetWindowsState())
            MouseEnterEvent();
    }
    public virtual void MouseEnterEvent()
    {
        GameManager.instance.SetInteractionTarget(this, cursorType);
    }
    public virtual void OnMouseExit()
    {
        GameManager.instance.CleanInteractionTarget(this);
    }

}
