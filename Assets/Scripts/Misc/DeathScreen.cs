using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public string sceneName;
    // Update is called once per frame
    void Update()
    {
        if (this.transform.GetChild(0).gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameHalper.instance.ChangeScene(sceneName);
            }
        }
    }

    public void Open()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
