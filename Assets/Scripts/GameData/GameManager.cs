using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//保存数据，书里说后面也可以把几个单例改了塞进来做中间层，没完全搞懂
public class GameManager : MonoBehaviour
{
    public GameData gameData;//游戏数据
    public CellTree cellTree;//技能树接口,给UI的buttons调用
                             //也可能会放到技能树panel里来实现技能点不足之类的提示  
    public SceneSwitcher sceneSwitcher;
    //单例
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
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
            gameData = new GameData();
            cellTree = new CellTree();
            sceneSwitcher = new SceneSwitcher();
        }
    }
}
