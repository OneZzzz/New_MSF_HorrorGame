using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNpc_classmate4 : InteractionNpcBase
{
    private LevelController_class_day levelController_Class_Day;
    public override void Start()
    {
        levelController_Class_Day = GameObject.FindObjectOfType<LevelController_class_day>();
        levelController_Class_Day.classmates.Add(this);
        base.Start();
    }
    public override void Next()
    {
        if (index != (messages.Count - 1))
        {
            base.Next();
        }
        else
        {
            player.interactionTipsController.ShowTips(InteractionTipsType.questionmark);
            Invoke("Wait", 2);
            base.Next();
        }
    }
    void Wait()
    {
        player.interactionTipsController.CloseTips(InteractionTipsType.questionmark);
    }
    public override void End()
    {
        levelController_Class_Day.FinshNpc(this);
        base.End();
    }
}
