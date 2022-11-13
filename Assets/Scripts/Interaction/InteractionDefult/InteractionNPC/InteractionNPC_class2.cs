using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC_class2 : InteractionNpcBase
{
    // public List<GameObject> ellipsis;
    // public List<GameObject> npcs;
    // public GameObject playerEllipsis;
    public string nextScene;
    public override void Start()
    {

    }
    public override void Next()
    {

        base.Next();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.L))
        {
            End();
        }
    }


    public override void End()
    {
        base.End();
        GameHalper.instance.Fade(false, 2, EnterNextScene, 0.5f, 0.2f);
    }

    private void EnterNextScene()
    {
        GameHalper.instance.ChangeScene(nextScene);
    }
}

