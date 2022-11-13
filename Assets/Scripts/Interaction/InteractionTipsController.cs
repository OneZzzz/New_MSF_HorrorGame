using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionTipsType
{
    ellipsis,
    questionmark
}

public class InteractionTipsController : MonoBehaviour
{
    private GameObject ellipsis, questionmark;

    private void Awake()
    {
        ellipsis = GameHalper.GetChildGameObjectByName(transform, "ellipsis");
        questionmark = GameHalper.GetChildGameObjectByName(transform, "question mark");
    }
    public void ShowTips(InteractionTipsType type)
    {
        ellipsis.SetActive(false);
        questionmark.SetActive(false);
        switch (type)
        {
            case InteractionTipsType.ellipsis:
                ellipsis.SetActive(true);
                break;
            case InteractionTipsType.questionmark:
                questionmark.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void CloseTips(InteractionTipsType type)
    {
        switch (type)
        {
            case InteractionTipsType.ellipsis:
                ellipsis.SetActive(false);
                break;
            case InteractionTipsType.questionmark:
                questionmark.SetActive(false);
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        Transform tipsParents = ellipsis.transform.parent;
        tipsParents.localScale = transform.localScale;
    }
}
