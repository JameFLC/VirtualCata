using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


// Utility Class that take a name and a data list and convert it in a single or multiline string in CSV format with the name followed by the data
// For data types each line hase a name followed by x/y/z/w ine the same box, each elements of vectors are separated in collumn
public class IODataSerializerCSV : MonoBehaviour
{
    private static int decimalNumber = 3;


    public static string SerializeFloats(string name, List<float> data)
    {
        string serializedData = '"' + name + '"' + SerializeFloatsList(data);
        return serializedData;
    }
    public static string SerializeVectors2(string name, List<Vector2> data)
    {
        string serializedData = null;

        List<float> datax = new List<float>(), datay = new List<float>();

        foreach (var item in data)
        {
            datax.Add(item.x);
            datay.Add(item.y);
        }
        serializedData += '"' + name + " X" + '"' + SerializeFloatsList(datax) + '"' + name + " Y" + '"' + SerializeFloatsList(datay);
        return serializedData;
    }
    public static string SerializeVectors3(string name, List<Vector3> data)
    {
        string serializedData = null;

        List<float> datax = new List<float>(), datay = new List<float>(), dataz = new List<float>();

        foreach (var item in data)
        {
            datax.Add(item.x);
            datay.Add(item.y);
            dataz.Add(item.z);
        }
        serializedData += '"' + name + " X" + '"' + SerializeFloatsList(datax)+ '"' + name + " Y" + '"' + SerializeFloatsList(datay)+ '"' + name + " Z" + '"' + SerializeFloatsList(dataz);
        return serializedData;
    }
    public static string SerializeVectors4(string name, List<Vector4> data)
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
        serializedData += '"' + name + " X" + '"' + SerializeFloatsList(datax) + '"' + name + " Y" + '"' + SerializeFloatsList(datay) + '"' + name + " Z" + '"' + SerializeFloatsList(dataz) + '"' + name + " W" + '"' + SerializeFloatsList(dataw);
        return serializedData;
    }
    public static string SerializeStrings(string name, List<string> data)
    {
        string serializedData = '"' + name + '"';
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
