using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance;
    }
    private GameObject dayLight;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        cursorEllipsis = Resources.Load<Texture2D>("ellipsis");
        cursorFind = Resources.Load<Texture2D>("find");
        dayLight = GameHalper.GetChildGameObjectByName(transform, "dayLight", false);
        if(dayLight==null)
            dayLight = GameHalper.GetChildGameObjectByName(transform, "DayLight", false);
    }

    private Texture2D cursorEllipsis, cursorFind;

    private InteractionBase interaction;
    public void SetInteractionTarget(InteractionBase interactionBase, CursorType cursorType)
    {
        interaction = interactionBase;
        CursorManager.instance.SetCursor(true, cursorType);

    }
    public InteractionBase GetInteractionTarget()
    {
        return interaction;
    }
    public void CleanInteractionTarget(InteractionBase interactionBase)
    {
        if (interaction == interactionBase)
        {
            interaction = null;
            CursorManager.instance.SetCursor(false, CursorType.defult);
        }
    }



    public void SetTime(bool isDay)
    {
        dayLight.SetActive(isDay);
    }
}
