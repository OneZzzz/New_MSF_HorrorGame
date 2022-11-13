using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InteractionMessage 
{
    public string name;
    [TextArea]
    public string message;
    public bool isClose_up;
    public Sprite close_upSprite;
    public Color nameColor = new Color(1,0.5f,0,1);
}
