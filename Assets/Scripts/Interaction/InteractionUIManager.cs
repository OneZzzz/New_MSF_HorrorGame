using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InteractionUIManager : MonoBehaviour
{
    public static InteractionUIManager instance;
    private void Awake()
    {
        if (InteractionUIManager.instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private GameObject close_up, dialogue,choose;
    private Text nameText;
    private Text messageText;

    private Text problemText, option1Text, option2Text;
    private Button option1Button, option2Button;

    private bool isUse;
    private void Start()
    {
        close_up = transform.GetChild(0).gameObject;
        dialogue = transform.GetChild(1).gameObject;
        choose = transform.GetChild(2).gameObject;
        problemText = choose.transform.GetChild(0).GetComponent<Text>();
        option1Text = choose.transform.GetChild(1).GetComponentInChildren<Text>();
        option2Text = choose.transform.GetChild(2).GetComponentInChildren<Text>();
        option1Button = choose.transform.GetChild(1).GetComponent<Button>();
        option2Button = choose.transform.GetChild(2).GetComponent<Button>();
        nameText = dialogue.transform.Find("name").GetComponent<Text>();
        messageText = dialogue.transform.Find("message").GetComponent<Text>();
    }

    public void ShowMessage(InteractionMessage messageData, Action action = null)
    {
        isUse = true;
        if (messageData.isClose_up)
        {
            close_up.SetActive(true);
            Image target = close_up.transform.GetChild(0).GetComponent<Image>();
            target.sprite = messageData.close_upSprite;
            target.SetNativeSize();
        }
        dialogue.SetActive(true);
        string modifyMessage = "";
        string modifyName = "";
        if (messageData.name != "")
        {
            for (int i = 0; i < messageData.name.Length * 2 + 6; i++)
            {
                modifyMessage += " ";
            }
            modifyName = messageData.name + " :";
        }
        modifyMessage += messageData.message;
        nameText.text = modifyName;
        nameText.color = messageData.nameColor;
        GameHalper.instance.WriteOpen(messageText, modifyMessage, action, 0.02f);
    }
    public void SkipMessage(InteractionMessage messageData, Action action)
    {
        string modifyMessage = "";
        if (messageData.name != "")
        {
            for (int i = 0; i < messageData.name.Length * 1 + 1; i++)
            {
                modifyMessage += " ";
            }
        }
        modifyMessage += messageData.message;
        GameHalper.instance.WriteClose(messageText, modifyMessage, action);
    }

    public void CloseMessage()
    {
        isUse = false;
        close_up.SetActive(false);
        dialogue.SetActive(false);
    }

    public void ShowChoose(string problem,string option1,string option2,Action action1,Action action2)
    {
        isUse = true;
        choose.SetActive(true);
        problemText.text = problem;
        option1Text.text = option1;
        option2Text.text = option2;
        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();
        option1Button.onClick.AddListener(()=>CloseChoose1(action1));
        option2Button.onClick.AddListener(()=> CloseChoose2(action2));
    }
    private void CloseChoose1(Action action)
    {
        choose.SetActive(false);
        isUse = false;
        if (action != null)
            action();
    }
    private void CloseChoose2(Action action)
    {
        choose.SetActive(false);
        isUse = false;
        if (action != null)
            action();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>true means play over,false means is in playing</returns>
    public bool GetDialoguePlayState()
    {
        return GameHalper.instance.GetWriteState();
    }

    public bool GetInteractionState()
    {
        return isUse;
    }
}
