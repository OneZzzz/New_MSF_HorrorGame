using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public virtual void Start()
    {
        gameObject.tag = "trigger";
    }
    public virtual void OnTriggerEnterEvent()
    {

    }
}
