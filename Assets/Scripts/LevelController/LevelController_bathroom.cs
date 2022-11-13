using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController_bathroom : LevelController
{
    private GameObject mask;
    private void Start()
    {
        mask = transform.GetChild(0).gameObject;
        mask.SetActive(true);
        GameHalper.instance.Wait(3.5f, FadeIN);

    }
    void FadeIN()
    {
        GameHalper.instance.Fade(true, 1, ShowDialogue, 0);
        Destroy(mask);
    }
    void ShowDialogue()
    {
        // Debug.Log("here");
        GetComponent<InteractionNpcBase>().OnPlayerInteraction(null);
    }
}
