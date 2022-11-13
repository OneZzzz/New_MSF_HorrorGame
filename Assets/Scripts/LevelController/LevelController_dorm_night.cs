using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController_dorm_night : LevelController
{
    public PlayerController player;
    private InteractionBase interaction;
    void Start()
    {
        player.gameObject.SetActive(false);
        interaction = GetComponent<InteractionBase>();
        
    }
    public void AnimationPlayerEvent()
    {
        player.gameObject.SetActive(true);
        interaction.OnPlayerInteraction(player);
    }
    
}
