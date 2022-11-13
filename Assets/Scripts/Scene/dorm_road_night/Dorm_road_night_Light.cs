using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorm_road_night_Light : MonoBehaviour
{
    private void Update()
    {
        if (!GameSave.instance.switchState.ContainsKey("hall"))
        {
            GameSave.instance.switchState.Add("hall", false);
            return;
        }
        if (GameSave.instance.switchState["hall"])
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
