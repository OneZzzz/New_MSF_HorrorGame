using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDestroy : MonoBehaviour
{
    public GameObject interactions;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Ghost")
        {
            other.gameObject.SetActive(false);
            interactions.SetActive(true);
            ShowDialogue();
        }
    }

    void ShowDialogue()
    {
        // Debug.Log("here");
        GetComponent<InteractionItemBase>().OnPlayerInteraction(FindObjectOfType<PlayerController>());
    }
}
