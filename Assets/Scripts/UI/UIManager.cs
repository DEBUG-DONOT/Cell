using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//UI切换
public class UIManager : MonoBehaviour
{   
    public UIButtons buttons;

    private Stack<BasePanel> panelStack;

    private static UIManager instance = null;
    public static UIManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            buttons = new UIButtons();
        }
    }
    public void PushPanel(BasePanel panel)
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }
        panelStack.Push(panel);
        panel.OnEnter();
    }
    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();
        if (panelStack.Count <= 0) return;
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();
        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }
}
//Button对应的方法，给panel调用,实现一些与UI切换无关的功能
public class UIButtons 
{
    public void Quit()
    {
        //
        Application.Quit();
    }
    public void CreateA(GameObject A)
    {
        //两种思路
        //A :Cell进入协程暂停，这里调SetPrefab(A)，SetPrefab(A)设置当前新细胞器为A，并唤起协程
        //B :写个事件，在这里invoke 有必要的话写个event类和eventManager
    }
}

