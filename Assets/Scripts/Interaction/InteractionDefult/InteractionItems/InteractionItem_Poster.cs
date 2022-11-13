using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem_Poster : InteractionItemBase
{
    public GameObject interactionItem_Poster;

    public override void End()
    {
        gameObject.SetActive( false);
        interactionItem_Poster.SetActive(  true);
        base.End();
    }

}
