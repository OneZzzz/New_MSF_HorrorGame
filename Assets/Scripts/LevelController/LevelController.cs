using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public bool isDay = true;
    private void OnEnable()
    {
        GameManager.instance.SetTime(isDay);
    }
}
