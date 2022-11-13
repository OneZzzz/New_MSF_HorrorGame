using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CursorType
{
    defult,
    ellipsis,
    find,
    opendoor,
    changeScene
}
public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private Transform cursor;
    private Animator animator;
    private bool windowsCursorState=true;

    void Start()
    {
        cursor = transform.GetChild(0);
        animator = cursor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cursor.position = Input.mousePosition;
    }
    public void SetCursor(bool visable, CursorType cursorType)
    {
        cursor.gameObject.SetActive(visable);
        animator.SetInteger("cursorType", (int)cursorType);
        if (visable)
            Cursor.visible = false;
        else
        {
            if (cursorType == CursorType.defult)
                Cursor.visible = true;
        }
    }
    public void SetWindowsCursor(bool visable)
    {
        windowsCursorState = visable;
        Cursor.visible = windowsCursorState;
    }
    public bool GetWindowsState()
    {
        return windowsCursorState;
    }
    public void Renew()
    {
        Cursor.visible = true;
        cursor.gameObject.SetActive(false);
    }
}
