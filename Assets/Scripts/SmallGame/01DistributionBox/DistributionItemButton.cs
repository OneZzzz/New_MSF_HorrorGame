using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DistributionItemButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        index++;
        AudioManager.instance.PlayAudio("Switch");
        if (index >= 4)
            index -= 4;
        SetPos();
        boxController.CheckResult();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Renew()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (GameSave.instance.switchState.ContainsKey("distribution"))
        {
            if(!GameSave.instance.switchState["distribution"])
                RandomGame();
        }
        else
        {
            RandomGame();
        }
        SetPos();
    }
    void RandomGame()
    {
        index = Random.Range(0, 4);
    }
    void SetPos()
    {
        transform.eulerAngles = Vector3.forward * 90 * index;
    }

    public int index;
    private DistributionBoxController boxController;
    public void GetController(DistributionBoxController controller)
    {
        boxController = controller;
    }


}
