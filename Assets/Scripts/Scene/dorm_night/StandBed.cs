using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandBed : MonoBehaviour
{
    public LevelController_dorm_night levelcomtroller;
    public void AnimationEvent()
    {
        this.gameObject.SetActive(false);
        levelcomtroller.AnimationPlayerEvent();
    }
}
