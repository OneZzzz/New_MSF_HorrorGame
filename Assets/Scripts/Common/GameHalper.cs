using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHalper : MonoBehaviour
{
    public static GameHalper instance;
    private void Awake()
    {
        if (GameHalper.instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private bool writeState = true;
    /// <summary>
    /// Wait Time Halper
    /// </summary>
    /// <param name="waitTime"></param>
    /// <param name="action"></param>
    public void Wait(float waitTime, Action action)
    {
        StartCoroutine(WaitIE(waitTime, action));
    }
    private IEnumerator WaitIE(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        if (action != null)
            action();
        yield return new WaitForEndOfFrame();
    }

    /// <summary>
    /// Fade Animation Halper
    /// </summary>
    /// <param name="fadeIn">true means fade in,false means fade out</param>
    /// <param name="fadeTime"></param>
    /// <param name="action"></param>
    /// <param name="fadeOverWaitTime"></param>
    public void Fade(bool fadeIn, float fadeTime, Action action, float fadeOverWaitTime = 0, float closeWaitTime = 0)
    {
        StartCoroutine(FadeIE(fadeIn, fadeTime, action, fadeOverWaitTime, closeWaitTime));
    }
    private IEnumerator FadeIE(bool fadeIn, float fadeTime, Action action, float fadeOverWaitTime, float closeWaitTime = 0)
    {
        GameObject target = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject temp = transform.GetChild(i).gameObject;
            if (temp.name == "fade" && !temp.activeSelf)
            {
                target = temp;
                target.SetActive(true);
                break;
            }
        }
        if (target == null)
        {
            GameObject fade = Resources.Load<GameObject>("fade");
            target = Instantiate(fade, transform);
            target.name = "fade";
        }
        Image fadeImage = target.GetComponent<Image>();
        int count = (int)(fadeTime * 100);
        Color currentColor;
        float lerp = 0;
        if (fadeIn)
        {
            currentColor = Color.black;
            fadeImage.color = currentColor;
            lerp = -1f / count;
        }
        else
        {
            currentColor = new Color(0, 0, 0, 0);
            fadeImage.color = currentColor;
            lerp = 1f / count;
        }
        for (int i = 0; i < count; i++)
        {
            float a = currentColor.a + lerp * (float)i;
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, a);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(fadeOverWaitTime);
        yield return new WaitForEndOfFrame();
        if (action != null)
            action();
        yield return new WaitForSeconds(closeWaitTime);
        target.SetActive(false);


    }

    /// <summary>
    /// start write message
    /// </summary>
    /// <param name="text"></param>
    /// <param name="message"></param>
    /// <param name="action"></param>
    /// <param name="interval"></param>
    public void WriteOpen(Text text, string message, Action action, float interval = 0.01f)
    {
        text.text = "";
        writeState = false;
        StartCoroutine(WriteIE(text, message, action, interval));
    }
    /// <summary>
    ///  skip write message
    /// </summary>
    /// <param name="text"></param>
    /// <param name="message"></param>
    /// <param name="action"></param>
    public void WriteClose(Text text, string message, Action action)
    {
        StopAllCoroutines();
        text.text = message;
        Wait(0.05f, () => writeState = true);
        if (action != null)
            action();
    }
    private IEnumerator WriteIE(Text text, string message, Action action, float interval)
    {
        for (int i = 0; i < message.Length; i++)
        {
            text.text = text.text + message[i];
            yield return new WaitForSeconds(interval);
        }
        yield return new WaitForEndOfFrame();
        if (action != null)
            action();
        writeState = true;
    }

    public bool GetWriteState()
    {
        return writeState;
    }


    public static T GetActiveComponment<T>(GameObject gameObject) where T : MonoBehaviour
    {
        T[] ts = gameObject.GetComponents<T>();
        for (int i = 0; i < ts.Length; i++)
        {
            if (ts[i].enabled)
                return ts[i];
        }
        return gameObject.GetComponent<T>();
    }

    public static GameObject GetChildGameObjectByName(Transform parents, string name, bool isActive = false)
    {
        for (int i = 0; i < parents.childCount; i++)
        {
            if (parents.GetChild(i).gameObject.name == name)
            {
                if (!isActive)
                {
                    return parents.GetChild(i).gameObject;
                }
                else if (parents.GetChild(i).gameObject.activeSelf)
                {
                    return parents.GetChild(i).gameObject;
                }

            }
            else
            {
                if (GetChildGameObjectByName(parents.GetChild(i), name, isActive) != null)
                    return GetChildGameObjectByName(parents.GetChild(i), name, isActive);
            }
        }
        return null;
    }
    private void CloseFade()
    {
        GameObject target = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject temp = transform.GetChild(i).gameObject;
            if (temp.name == "fade" && !temp.activeSelf)
            {
                target = temp;
                target.SetActive(false);
            }
        }
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        CursorManager.instance.Renew();
    }
}
