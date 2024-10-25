using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    public void SwitchToScene(string name)
    {
        if (SceneManager.GetSceneByName(name).IsValid())
            Debug.LogError("missing a scene!");
        SceneManager.LoadScene(name);
    }
}