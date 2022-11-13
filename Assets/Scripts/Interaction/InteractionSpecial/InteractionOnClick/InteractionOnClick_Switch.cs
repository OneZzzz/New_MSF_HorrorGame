using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOnClick_Switch : InteractionOnClickBase
{
    public SwitchController switchCtrl;
    public override void Event()
    {
        switchCtrl.OpenSwitch(player);
    }
}
