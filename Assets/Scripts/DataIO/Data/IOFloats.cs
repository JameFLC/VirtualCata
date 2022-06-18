
using System.Collections.Generic;


public class IOFloats : IOData
{
    protected List<float> dataList = new List<float>();

    public IOFloats(string name) : base(name)
    {
        _name = name;
    }

    public override void AddData(IODataUnit data)
    {
        dataList.Add(data.GetFloat());
    }

    public override string SerializeData()
    {
        return IODataSerializerCSV.SerializeFloats(_name, dataList);
    }

    
}
