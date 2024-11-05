using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//UI�л�
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
//Button��Ӧ�ķ�������panel����,ʵ��һЩ��UI�л��޹صĹ���
public class UIButtons 
{
    public void Quit()
    {
        //
        Application.Quit();
    }
    public void CreateA(GameObject A)
    {
        //����˼·
        //A :Cell����Э����ͣ�������SetPrefab(A)��SetPrefab(A)���õ�ǰ��ϸ����ΪA��������Э��
        //B :д���¼���������invoke �б�Ҫ�Ļ�д��event���eventManager
    }
}

