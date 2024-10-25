using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasePanel : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    public virtual void OnEnter()
    {
        Time.timeScale = 0f;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public virtual void OnExit()
    {
        Time.timeScale = 1f;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    public virtual void OnPause()
    {
        Time.timeScale = 1f;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = false;
    }
    public virtual void OnResume()
    {
        Time.timeScale = 0f;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
}
