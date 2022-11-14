using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem_103_door : InteractionItemBase
{
    public LightFlicker lightFlicker;
    public GameObject ghost;
    public GameObject interactions;

    public override void Next()
    {
        if (index == 2)
        {
            ghost.SetActive(true);
            interactions.SetActive(false);
            lightFlicker.EnqueueIntensity(1f);
            lightFlicker.EnqueueIntensity(0.3f);
            lightFlicker.EnqueueIntensity(1.5f);
            lightFlicker.EnqueueIntensity(0f);
        }
        base.Next();
    }

    public override void End()
    {
        gameObject.SetActive(false);
        GameSave.instance.day[1] = true;
        base.End();
    }
}
