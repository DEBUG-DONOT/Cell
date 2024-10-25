using System.Collections;
using System.Collections.Generic;
using System.Linq;
//需要持久化的数据
public class GameData
{
    private int levelNumber;
    public int LevelNumber {
        get { return levelNumber; }
        set { levelNumber = value; }
    }
    public List<CellData> AllCellData { get; set; }

    private int skillPoint;
    public int SkillPoint
    {
        get { return skillPoint; }
        set { skillPoint = value; }
    }

    public CellData GetCellDataByName(string name)
    {
        CellData cellData = AllCellData.Where(cell=>cell.Name==name).FirstOrDefault();
        if(cellData!=null)return cellData;
        return null;
    }
    public bool CheckIsUnlocked(string name)
    {
        if(GetCellDataByName(name).isLocked)return false;
        return true;
    }
    public void Unlock(string name)
    {
        AllCellData.Where(cell => cell.Name == name).FirstOrDefault().isLocked = false;
    }
    public void Lock(string name)
    {
        AllCellData.Where(cell => cell.Name == name).FirstOrDefault().isLocked = true;
    }
}
