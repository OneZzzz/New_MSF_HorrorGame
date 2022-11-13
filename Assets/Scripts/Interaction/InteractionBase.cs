using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    [HideInInspector]
    public PlayerController player;

    public CursorType cursorType;


    public virtual void OnPlayerInteraction(PlayerController player)
    {
        
    }
    
}
