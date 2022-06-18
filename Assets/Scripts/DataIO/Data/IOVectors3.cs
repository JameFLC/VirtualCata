using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOVectors3 : IOData
{
    protected List<Vector3> dataList = new List<Vector3>();
    public IOVectors3(string name) : base(name)
    {
        _name = name;
    }

    public override void AddData(IODataUnit data)
    {
        dataList.Add(data.GetVector3());
    }

    public override string SerializeData()
    {
        return IODataSerializerCSV.SerializeVectors3(_name, dataList);
    }
}
