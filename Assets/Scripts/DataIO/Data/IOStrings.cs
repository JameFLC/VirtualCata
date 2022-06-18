using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOStrings : IOData
{
    protected List<string> dataList = new List<string>();
    public IOStrings(string name) : base(name)
    {
        _name = name;
    }

    public override void AddData(IODataUnit data)
    {
        dataList.Add(data.GetString());
    }

    public override string SerializeData()
    {
        return IODataSerializerCSV.SerializeStrings(_name, dataList);
    }
}
