using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_restroom_door : InteractionChooseBase
{
    public GameObject elseStateDoor;
    public override void Option1()
    {
        elseStateDoor.SetActive(true);
        gameObject.SetActive(false);
        player.enabled = true;
    }
    public override void Option2()
    {
        player.enabled = true;
    }
}
