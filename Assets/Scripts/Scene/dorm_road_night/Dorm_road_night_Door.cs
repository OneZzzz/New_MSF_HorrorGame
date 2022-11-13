using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorm_road_night_Door : MonoBehaviour
{
    private void Update()
    {
        if (GameSave.instance.openDoor)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
