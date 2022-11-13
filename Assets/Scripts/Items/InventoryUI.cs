using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private static InventoryUI instance;
    public bool isActive = false;
    private InventorySystem inventory;
    public GameObject inventoryUI;
    private ItemSlot[] slots;

    public delegate void OnInventoryOpen();
    public OnInventoryOpen OnInventoryOpenCallback;

    public delegate void OnInventoryClose();
    public OnInventoryClose OnInventoryCloseCallback;

    public GameObject defaulSelectedObject;

    public TextMeshProUGUI nameTxt;
    public Image itemImg;
    public TextMeshProUGUI descTxt;
    public GameObject dialogueBox;

    public static InventoryUI FindInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }

        inventoryUI.SetActive(false);
    }

    private void Start()
    {
        inventory = InventorySystem.FindInstance();
        inventory.OnItemChangedCallback += UpdateUI;

        slots = inventoryUI.GetComponentsInChildren<ItemSlot>();
        // dialogueBox = GameObject.FindGameObjectWithTag("dialoguebox");
    }

    private void Update()
    {
        // Debug.Log(InteractionUIManager.instance.GetDialoguePlayState());
        if (dialogueBox.activeSelf == true)
        {
            isActive = false;
            inventoryUI.SetActive(false);

            if (OnInventoryCloseCallback != null)
            {
                OnInventoryCloseCallback.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Toggle();
        }

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaulSelectedObject);
        }
        else
        {
            UpdateDescription();
        }
    }

    private void UpdateDescription()
    {
        ItemSlot slot = EventSystem.current.currentSelectedGameObject.GetComponent<ItemSlot>();
        if (slot == null) return;
        if (slot.nameTxt != "")
        {
            nameTxt.text = slot.nameTxt;
            descTxt.text = slot.descTxt;
            itemImg.sprite = slot.icon.sprite;
        }
        else
        {
            nameTxt.text = "";
            descTxt.text = "";
            itemImg.sprite = null;
        }
    }

    private void Toggle()
    {
        // Debug.Log(InteractionUIManager.instance.GetDialoguePlayState());
        if (dialogueBox.activeSelf == true)
        {
            isActive = false;
            inventoryUI.SetActive(false);

            if (OnInventoryCloseCallback != null)
            {
                OnInventoryCloseCallback.Invoke();
            }
        }
        else
        {
            if (isActive)
            {
                isActive = false;
                inventoryUI.SetActive(false);

                if (OnInventoryCloseCallback != null)
                {
                    OnInventoryCloseCallback.Invoke();
                }
            }
            else
            {
                isActive = true;
                inventoryUI.SetActive(true);

                if (OnInventoryOpenCallback != null)
                {
                    OnInventoryOpenCallback.Invoke();
                }
            }
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.inventory.Count)
            {
                // Debug.Log(inventory.inventory[i].data.displayName);
                slots[i].AddItem(inventory.inventory[i]);
            }
            else
            {
                // slots[i].ClearSlot();
            }
        }
    }
}
