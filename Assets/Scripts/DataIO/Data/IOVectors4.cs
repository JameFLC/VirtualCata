using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOVectors4 : IOData
{
    protected List<Vector4> dataList = new List<Vector4>();

    public IOVectors4(string name) : base(name)
    {
        _name = name;
    }

    public override void AddData(IODataUnit data)
    {
        dataList.Add(data.GetVector4());
    }

    public override string SerializeData()
    {
        return IODataSerializerCSV.SerializeVectors4(_name, dataList);
    }
}
