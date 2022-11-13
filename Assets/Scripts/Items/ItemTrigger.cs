using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTrigger : MonoBehaviour
{
    public ItemData referenceItem;

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         // txt.SetActive(true);

    //         if (Input.GetKeyDown(KeyCode.E))
    //         {
    //             OnHandlePickupItem();
    //         }
    //     }
    // }

    public void OnHandlePickupItem()
    {
        InventorySystem.FindInstance().Add(referenceItem);
        // gameObject.transform.parent.GetComponent<Interaction_Item_Pickup>().OnPlayerInteraction(GameObject.FindObjectOfType<PlayerController>());
        // InteractionUIManager.instance.ShowMessage(gameObject.GetComponent<InteractionBase>().messages);
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
