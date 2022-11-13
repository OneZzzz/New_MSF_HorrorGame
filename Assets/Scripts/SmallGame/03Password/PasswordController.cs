using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordController : MonoBehaviour
{
    public List<string> password = new List<string>();
    private List<GameObject> lights = new List<GameObject>();
    private string truePassword = "0413";
    private PlayerController player;
    private void Start()
    {
        for (int i = 0; i < transform.GetChild(0).GetChild(0).GetChild(0).childCount; i++)
        {
            lights.Add(transform.GetChild(0).GetChild(0).GetChild(0).GetChild(i).gameObject);
            lights[i].SetActive(false);
        }
    }
    public void SetPassword(string number)
    {
        AudioManager.instance.PlayAudio("EnterPasscode");
        if (GameSave.instance.openDoor) 
            return;
        if (!GameSave.instance.switchState.ContainsKey("gate"))
            return;
        if (!GameSave.instance.switchState["gate"])
            return;
        password.Add(number);
        ShowNumber();
    }
    public void CleanPassword()
    {
        if (GameSave.instance.openDoor) return;
        if (!GameSave.instance.switchState.ContainsKey("gate"))
            return;
        if (!GameSave.instance.switchState["gate"])
            return;
        password = new List<string>();
        ShowNumber();
    }
    public void ComfirmPassword()
    {
        if (GameSave.instance.openDoor) return;
        if (!GameSave.instance.switchState.ContainsKey("gate"))
            return;
        if (!GameSave.instance.switchState["gate"])
            return;
        if (password.Count != 4) return;
        string result = string.Empty;
        foreach (var item in password)
        {
            result += item;
        }
        if (result != truePassword)
        {
            AudioManager.instance.PlayAudio("Wrong_Passcode");
            CleanPassword();
        }
        else
        {
            AudioManager.instance.PlayAudio("HallGate_Open");
            GameSave.instance.openDoor = true;
            Close();
        }
    }

    private void ShowNumber()
    {
        foreach (var item in lights)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < password.Count; i++)
        {
            lights[i].SetActive(true);
        }
    }

    public void Close()
    {
        player.enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void Open(PlayerController player)
    {
        this.player = player;
        player.enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        if (!GameSave.instance.openDoor)
            CleanPassword();
        else
        {
            foreach (var item in lights)
            {
                item.SetActive(true);
            }
        }
    }
}
