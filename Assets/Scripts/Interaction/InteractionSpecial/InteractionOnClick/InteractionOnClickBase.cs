using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOnClickBase : InteractionSpecial
{
    public override void OnPlayerInteraction(PlayerController player)
    {
        base.OnPlayerInteraction(player);
        Event();
    }
    public virtual void Event()
    {
        
    }
}
