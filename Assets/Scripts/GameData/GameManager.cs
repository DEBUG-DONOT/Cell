using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//�������ݣ�����˵����Ҳ���԰Ѽ��������������������м�㣬û��ȫ�㶮
public class GameManager : MonoBehaviour
{
    public GameData gameData;//��Ϸ����
    public CellTree cellTree;//�������ӿ�,��UI��buttons����
                             //Ҳ���ܻ�ŵ�������panel����ʵ�ּ��ܵ㲻��֮�����ʾ  
    public SceneSwitcher sceneSwitcher;
    //����
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
