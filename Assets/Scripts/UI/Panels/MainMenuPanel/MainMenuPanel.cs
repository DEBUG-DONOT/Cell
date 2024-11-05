using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    //后续可以放Buttons里,或者写个类放panel里的东西
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


