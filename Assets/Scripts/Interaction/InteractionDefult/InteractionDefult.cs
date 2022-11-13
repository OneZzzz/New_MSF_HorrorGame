using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDefult : InteractionBase
{
    public List<InteractionMessage> messages;
    [HideInInspector]
    public int index;
    protected bool checkIn;


    public virtual void Start()
    {

    }

    public virtual void OnPlayerEnter(PlayerController player)
    {

    }
    public virtual void OnPlayerExit(PlayerController player)
    {

    }
    public override void OnPlayerInteraction(PlayerController player)
    {
        CursorManager.instance.SetWindowsCursor(false);
        if (messages != null && messages.Count != 0)
        {
            index = 0;
            this.player = player;
            if (player != null)
                player.enabled = false;
            if (messages[0].isClose_up)
                GameHalper.instance.Fade(false, 1f, () => ShowInteractionMessage());
            else
                ShowInteractionMessage();
        }
        else
        {
            InteractionEvent();
        }
    }
    public virtual void InteractionEvent()
    {

    }

    public virtual void ShowInteractionMessage()
    {
        if (index >= messages.Count)
        {
            CursorManager.instance.SetWindowsCursor(true);
            End();
        }
        else
        {
            Next();
        }
    }
    public virtual void End()
    {
        Cursor.visible = true;
        InteractionUIManager.instance.CloseMessage();
        checkIn = false;
        if (player != null)
            player.enabled = true;
    }
    public virtual void Next()
    {
        checkIn = true;
        InteractionUIManager.instance.ShowMessage(messages[index]);
        index++;
    }

    protected virtual void Update()
    {
        CheckM();
    }
    public virtual void CheckM()
    {
        if (checkIn)
        {
            if (InteractionUIManager.instance.GetDialoguePlayState())
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                {
                    // Debug.Log("here");
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
    public virtual void OnMouseEnter()
    {
        if (this.enabled && CursorManager.instance.GetWindowsState())
            MouseEnterEvent();
    }
    public virtual void MouseEnterEvent()
    {
        GameManager.instance.SetInteractionTarget(this, cursorType);
    }
    public virtual void OnMouseExit()
    {
        GameManager.instance.CleanInteractionTarget(this);
    }
}
