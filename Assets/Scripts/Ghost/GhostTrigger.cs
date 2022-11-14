using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    [SerializeField] private Ghost ghostScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ghostScript.canKill && other.tag == "Player")
        {
            Debug.Log("Die");
        }
    }
}
