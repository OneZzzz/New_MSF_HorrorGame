using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNpc_bathroom : InteractionNpcBase
{
    public List<GameObject> ellipsis;
    public List<GameObject> npcs;
    public GameObject playerEllipsis;
    public override void Start()
    {
        
    }
    public override void Next()
    {
        if (index ==2)
        {
            foreach (var item in ellipsis)
            {
                item.SetActive(true);
            }
        }
        if (index == 3)
        {
            foreach (var item in ellipsis)
            {
                item.SetActive(false);
            }
        }
        if (index == 18)
        {
            foreach (var item in npcs)
            {
                item.SetActive(false);
            }
            playerEllipsis.SetActive(true);
        }
        if (index == 19)
        {
            playerEllipsis.SetActive(false);
        }
        else
        {
            
        }
        base.Next();
    }
    public override void End()
    {
        base.End();
        GameHalper.instance.Fade(false, 2f, () => GameHalper.instance.ChangeScene("dorm_night"), 0.2f, 0.2f);
    }
    
}

