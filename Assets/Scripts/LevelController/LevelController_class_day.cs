using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController_class_day : LevelController
{
    public PlayerController playerController;
    private InteractionItemBase interactionIntroduce_scene;
    private GameObject xiaolv;
    [HideInInspector]
    public List<InteractionNpcBase> classmates = new List<InteractionNpcBase>();
    private List<GameObject> npcs = new List<GameObject>();

    private void Start()
    {
        interactionIntroduce_scene = GetComponent<InteractionItemBase>();
        playerController.gameObject.SetActive(false);
        playerController.enabled = false;
        GameHalper.instance.Fade(true, 1f, null, 0.3f);
        xiaolv = GameHalper.GetChildGameObjectByName(transform, "xiaolv");
        xiaolv.SetActive(false);
    }

    public void ShowTips()
    {
        this.gameObject.SetActive(true);
        playerController.gameObject.SetActive(true);
        interactionIntroduce_scene.OnPlayerInteraction(playerController);
    }
    public void FinshNpc(InteractionNpcBase npc)
    {
        if (classmates.Contains(npc))
        {
            npcs.Add(npc.gameObject);
            classmates.Remove(npc);
            if (classmates.Count == 0)
                ShowXiaolv();
        }
    }

    private void ShowXiaolv()
    {
        foreach (var item in npcs)
        {
            //item.SetActive(false);
        }
        xiaolv.SetActive(true);
    }
}
