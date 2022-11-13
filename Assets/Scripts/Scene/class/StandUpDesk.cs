using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpDesk : MonoBehaviour

{
    public LevelController_class_day levelController;
    public void AnimationEvent()
    {
        this.gameObject.SetActive(false);
        levelController.ShowTips();
    }
}
