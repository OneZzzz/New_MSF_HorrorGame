using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        GameHalper.instance.ChangeScene(name);
    }
}
