using System.Collections.Generic;
using UnityEngine;


public class IOVectors2 : IOData
{
    protected List<Vector2> dataList = new List<Vector2>();

    public IOVectors2(string name) : base(name)
    {
        _name = name;
    }

    public override void AddData(IODataUnit data)
    {
        dataList.Add(data.GetVector2());
    }

    public override string SerializeData(float updateDelay)
    {
        return IODataSerializerCSV.SerializeVectors2(_name, dataList,updateDelay);
    }

    
}
