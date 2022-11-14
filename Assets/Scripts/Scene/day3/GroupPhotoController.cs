using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupPhotoController : MonoBehaviour
{
    public PlayerController player;
    private BoxCollider2D boxCollider;
    private bool isPlay = false;
    void Start()
    {
        if (GameSave.instance.items.ContainsKey(gameObject.name + GameHalper.GetSceneName()))
        {
            gameObject.SetActive(false);
            return;
        }
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }


    void Update()
    {
        if (!isPlay)
            PlayerEnter();
    }
    void PlayerEnter()
    {
        if (!(player.transform.position.x > transform.position.x + 2))
            return;
        isPlay = true;
        gameObject.AddComponent<Rigidbody2D>();
        boxCollider.enabled = true;
        AudioManager.instance.PlayAudio("Photo_Fall");
        GetComponent<InteractionBase>().enabled = true;
    }
}
