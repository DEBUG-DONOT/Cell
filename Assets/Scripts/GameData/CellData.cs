using System.Collections;
using System.Collections.Generic;

public class CellData 
{
    private string name;
    public string Name 
    { 
        get { return name; } 
        set { name=value; } 
    }

    //public int Id{get;set;}
    private int cost;
    public int Cost 
    {
        get {return cost; }
        set { cost = value; } 
    }

    private string des;
    public string Description 
    {
        get { return des; }
        set { des = value; } 
    }

    private string lowerCell;
    public string LowerCell 
    {
        get { return lowerCell; }
        set { lowerCell = value; } 
    }
    public List<string> PreCell { get; set; }=new List<string>();

    //public CellType cellType{get;set;}

    //some possible standard data of cell
    public bool isLocked;
}
/*
public enum CellType
{

}*/
public class CellDataList
{
    public List<CellData> cellDatas;
    public CellDataList()
    {
        cellDatas = new List<CellData>();
    }
}