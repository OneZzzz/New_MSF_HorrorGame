using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUIManager : MonoBehaviour
{
    public static StateUIManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private List<GameObject> states = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            states.Add(transform.GetChild(i).gameObject);
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SetState(string name, bool state)
    {
        Debug.Log(name);
        CheckStateState(name).SetActive(state);
    }
    public bool GetState(string name)
    {
        return CheckStateState(name).activeSelf;
    }
    private GameObject CheckStateState(string name)
    {
        for (int i = 0; i < states.Count; i++)
        {
            if (states[i].name == name)
                return states[i];
        }
        return null;
    }
}
