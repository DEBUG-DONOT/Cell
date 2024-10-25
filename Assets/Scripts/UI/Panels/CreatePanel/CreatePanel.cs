using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePanel : BasePanel
{
    [SerializeField] private GameObject APrefab;
    [SerializeField] private Button CreateA;
    private static CreatePanel instance;
    public static CreatePanel Instance { get { return instance; } }
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
        CreateA.onClick.AddListener(OnCreateA);
    }
    public void OnCreateA()
    {
        UIManager.Instance.buttons.CreateA(APrefab);
    }
}
