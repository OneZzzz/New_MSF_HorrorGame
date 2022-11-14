using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionItemBase))]
public class LevelController_defultSave : LevelController
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
        if (!GameSave.instance.level.ContainsKey(GameHalper.GetSceneName()))
        {
            GameSave.instance.level.Add(GameHalper.GetSceneName(), true);
            interaction_scene.OnPlayerInteraction(playerController);
        }
        else
        {
            playerController.enabled = true;
        }
    }
}
