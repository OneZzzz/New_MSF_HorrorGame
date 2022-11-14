using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3RestroomController : MonoBehaviour
{
    void Start()
    {
        if (GameSave.instance.switchState.ContainsKey("tollet"))
        {
            if (GameSave.instance.switchState["tollet"])
            {
                transform.GetChild(0).gameObject.SetActive(true);
                return;
            }
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }


}
