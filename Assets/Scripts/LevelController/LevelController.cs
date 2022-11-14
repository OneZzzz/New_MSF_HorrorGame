using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public bool isDay = true;
    private void OnEnable()
    {
        if (GameManager.instance != null)
            GameManager.instance.SetTime(isDay);
        else
            GameObject.FindObjectOfType<GameManager>().SetTime(isDay);
    }
}
