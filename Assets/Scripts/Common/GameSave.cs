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




}
