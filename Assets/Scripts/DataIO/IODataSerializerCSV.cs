using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


// Utility Class that take a name and a data list and convert it in a single or multiline string in CSV format with the name followed by the data
// For data types each line hase a name followed by x/y/z/w ine the same box, each elements of vectors are separated in collumn
public class IODataSerializerCSV : MonoBehaviour
{
    private static int decimalNumber = 3;


    public static string SerializeFloats(string name, List<float> data,float updateDelay)
    {
        string serializedData = '"' + name + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" +'"' + SerializeFloatsList(data);
        return serializedData;
    }
    public static string SerializeVectors2(string name, List<Vector2> data, float updateDelay)
    {
        string serializedData = null;

        List<float> datax = new List<float>(), datay = new List<float>();

        foreach (var item in data)
        {
            datax.Add(item.x);
            datay.Add(item.y);
        }
        serializedData += '"' + name + " X" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(datax) + '"' + name + " Y" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(datay);
        return serializedData;
    }
    public static string SerializeVectors3(string name, List<Vector3> data, float updateDelay)
    {
        string serializedData = null;

        List<float> datax = new List<float>(), datay = new List<float>(), dataz = new List<float>();

        foreach (var item in data)
        {
            datax.Add(item.x);
            datay.Add(item.y);
            dataz.Add(item.z);
        }
        serializedData += '"' + name + " X" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(datax)+ '"' + name + " Y" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(datay)+ '"' + name + " Z" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(dataz);
        return serializedData;
    }
    public static string SerializeVectors4(string name, List<Vector4> data, float updateDelay)
    {
        string serializedData = null;

        List<float> datax = new List<float>(), datay = new List<float>(), dataz = new List<float>(), dataw = new List<float>();

        foreach (var item in data)
        {
            datax.Add(item.x);
            datay.Add(item.y);
            dataz.Add(item.z);
            dataw.Add(item.w);
        }
        serializedData += '"' + name + " X" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(datax) + '"' + name + " Y" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(datay) + '"' + name + " Z" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(dataz) + '"' + name + " W" + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"' + SerializeFloatsList(dataw);
        return serializedData;
    }
    public static string SerializeStrings(string name, List<string> data, float updateDelay)
    {
        string serializedData = '"' + name + " {" + updateDelay.ToString("F" + 3, CultureInfo.InvariantCulture) + "}" + '"';
        foreach (var item in data)
        {
            serializedData += "," + '"' + item + '"';
        }
        return serializedData + "\n";
    }
    private static string SerializeFloatsList(List<float> data)
    {
        string serializedData = "";
        foreach (var item in data)
        {
            serializedData += "," + item.ToString("F"+decimalNumber, CultureInfo.InvariantCulture);
        }
        return serializedData + "\n";
    }
}
