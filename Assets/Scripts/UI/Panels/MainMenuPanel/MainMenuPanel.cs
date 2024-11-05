using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    //�������Է�Buttons��,����д�����panel��Ķ���
    [SerializeField] private Button StartButton;
    [SerializeField] private Button QuitButton;

    private static MainMenuPanel instance;
    public static MainMenuPanel Instance { get { return instance; } }
     void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }
    }
    private void Start()
    {
        StartButton.onClick.AddListener(OnStartButton);
        QuitButton.onClick.AddListener(OnQuitButton);
    }
    public void OnStartButton()
    {
        UIManager.Instance.PopPanel();
    }
    public void OnQuitButton()
    {
        UIManager.Instance.buttons.Quit();
    }
}


