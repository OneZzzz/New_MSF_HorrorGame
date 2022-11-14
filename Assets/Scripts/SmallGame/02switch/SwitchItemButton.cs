using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchItemButton : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.PlayAudio("Switch");
        switchController.SetSwitch(gameObject.name);
        if (switchController.GetNumber())
            AudioManager.instance.PlayAudio("Power_Operate");
    }
    private  SwitchController switchController;
    public void SetSwitch(SwitchController sw)
    {
        switchController = sw;
    }
    
}
