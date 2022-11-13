using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNpc_classmate : InteractionNpcBase
{
    private LevelController_class_day levelController_Class_Day;
    public override void Start()
    {
        levelController_Class_Day = GameObject.FindObjectOfType<LevelController_class_day>();
        levelController_Class_Day.classmates.Add(this);
        base.Start();
    }

    public override void End()
    {
        levelController_Class_Day.FinshNpc(this);
        base.End();
    }
}
