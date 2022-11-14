using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem_DayFinsh_Base : InteractionItemBase
{
    public int dayCount;
    public override void End()
    {
        base.End();
        GameSave.instance.day[dayCount] = true;
    }
}
