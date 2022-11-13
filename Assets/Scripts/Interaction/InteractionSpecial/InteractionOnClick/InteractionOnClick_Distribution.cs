using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOnClick_Distribution : InteractionOnClickBase
{
    public DistributionBoxController distribution;
    public override void Event()
    {
        distribution.Open(player);
    }
}
