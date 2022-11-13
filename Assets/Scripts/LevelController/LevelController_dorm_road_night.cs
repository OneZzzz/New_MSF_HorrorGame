using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController_dorm_road_night : LevelController
{
    private PlayerController playerController;
    private InteractionItemBase interaction_scene;
    private void Start()
    {
        interaction_scene = GetComponent<InteractionItemBase>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        playerController.enabled = false;
        GameHalper.instance.Fade(true, 1f, () => ShowTips(), 0.3f);
    }

    void ShowTips()
    {
        interaction_scene.OnPlayerInteraction(playerController);
    }
}
