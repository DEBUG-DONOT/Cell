using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellTree 
{
    //可以继承mono写成单例，或者当组件
    private GameData data=GameManager.Instance.gameData;
    public void UnlockNode(CellData cellData)
    {
        if (cellData == null) Debug.LogError("invalid cell name");
        if (data.SkillPoint < cellData.Cost)return;
        foreach(var precell in cellData.PreCell)
        {
            if(!data.CheckIsUnlocked(precell))
                return;
        }
        data.SkillPoint -= cellData.Cost;
        data.Unlock(cellData.Name);
    }
    public void LockNode(CellData cellData)//递归先用着，后面再改
    {
        data.SkillPoint += cellData.Cost;
        if(!cellData.isLocked)data.Lock(cellData.Name);
        else return;
        List<CellData> childs=data.AllCellData.Where(x=>x.PreCell.Contains(cellData.Name)).ToList();
        if(childs.Count > 0)
        {
            foreach(var child in childs)LockNode(child);
        }
    }
    public void Reset()
    {
        foreach(var cell in data.AllCellData)
        {
            data.SkillPoint += cell.Cost;
            if(!cell.isLocked) data.Lock(cell.Name);
        }
    }
}
