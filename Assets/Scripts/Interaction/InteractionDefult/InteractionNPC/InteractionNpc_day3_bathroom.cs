using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNpc_day3_bathroom : InteractionNpcBase
{
    public GameObject ellipsis;
    public GameObject problem;
    public List<GameObject> npc;
    public GameObject xiaolv;
    public override void Start()
    {

    }
    public override void Next()
    {
        if (index == 1)
        {
            problem.SetActive(true);
            GameHalper.instance.Wait(2f, () => problem.SetActive(false));
        }
        else if (index == 2)
        {
            problem.SetActive(false);
        }
        else if (index == 13)
        {
            for (int i = 0; i < npc.Count; i++)
            {
                npc[i].SetActive(false);
            }
            ellipsis.SetActive(true);
            GameHalper.instance.Wait(2f, () => ellipsis.SetActive(false));
            xiaolv.SetActive(true);
        }
        else if (index == 14)
        {
            ellipsis.SetActive(false);
        }
        
        base.Next();
    }
    public override void End()
    {
        base.End();
        GameHalper.instance.Fade(false, 2f, () => GameHalper.instance.ChangeScene("day3_dorm_night"), 0.2f, 0.2f);
    }

}
