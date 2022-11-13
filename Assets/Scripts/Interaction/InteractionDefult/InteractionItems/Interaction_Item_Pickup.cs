using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Item_Pickup : InteractionDefult
{
    public ItemTrigger item;

    public override void Start()
    {
        gameObject.tag = "InteractionItem";
        cursorType = CursorType.find;
    }

    public override void MouseEnterEvent()
    {
        // Debug.Log(this);
        // Debug.Log(cursorType);
        GameManager.instance.SetInteractionTarget(this, cursorType);
    }

    public override void CheckM()
    {
        if (checkIn)
        {
            if (InteractionUIManager.instance.GetDialoguePlayState())
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                {
                    Debug.Log("here");
                    item.OnHandlePickupItem();
                    // ShowInteractionMessage();
                    ShowInteractionMessage();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                {
                    InteractionUIManager.instance.SkipMessage(messages[index - 1], null);
                }
            }
        }
    }
}

