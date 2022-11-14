using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNpc_day3_restroom_xiaolv : InteractionNpcBase
{

    public override void Next()
    {
        if (index ==0)
        {
            player.interactionTipsController.ShowTips(InteractionTipsType.questionmark);
        }
        else if(index==messages.Count-1)
        {
            player.interactionTipsController.CloseTips(InteractionTipsType.questionmark);
        }
        base.Next();
    }
    public override void End()
    {
        gameObject.SetActive(false);
        base.End();
    }

}
