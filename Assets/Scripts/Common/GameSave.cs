using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public static GameSave instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    [HideInInspector]
    public LightState currentLightState;




    public Dictionary<string, bool> switchState = new Dictionary<string, bool>();

    public bool openDoor;

    public Dictionary<string, bool> level = new Dictionary<string, bool>();
    public Dictionary<string, bool> items = new Dictionary<string, bool>();

}
