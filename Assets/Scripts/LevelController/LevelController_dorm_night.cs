using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController_dorm_night : LevelController
{
    public PlayerController player;
    private InteractionBase interaction;
    public GameObject animation;
    void Start()
    {
        player.gameObject.SetActive(false);
        interaction = GetComponent<InteractionBase>();
        if (!GameSave.instance.level.ContainsKey(GameHalper.GetSceneName()))
        {
            GameSave.instance.level.Add(GameHalper.GetSceneName(), true);
        }
        else
        {
            animation.SetActive(false);
            player.gameObject.SetActive(true);
            player.enabled = true;
        }
        
    }
    public void AnimationPlayerEvent()
    {
        player.gameObject.SetActive(true);
        interaction.OnPlayerInteraction(player);
    }
    
}
