using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public PlayerController player;

    private void OnMouseDown()
    {
        if(player.GetMovementState()==MovementState.crouch)
        isFollow = true;
        
    }
    private void OnMouseUp()
    {
        isFollow = false;
    }
    private bool isFollow;
    private void Update()
    {
        if (isFollow)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector3(pos.x, pos.y, 0);
            transform.position =pos ;
        }
    }
}
