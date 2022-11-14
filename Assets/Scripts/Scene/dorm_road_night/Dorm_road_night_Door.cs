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
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
