using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IODataDebug : MonoBehaviour
{
    [SerializeField] int datalenght = 15;
    [SerializeField] int stringMedianLenght = 7;
    [SerializeField] int stringVariation = 2;




    const string _glyphs = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789 "; //add the characters you want
    // Start is called before the first frame update
    void Start()
    {
        IOVectors4 iOVectors4 = new IOVectors4("vector4");
        IOVectors3 iOVectors3 = new IOVectors3("vector3");
        IOVectors2 iOVectors2 = new IOVectors2("vector2");
        IOFloats iOFloats = new IOFloats("float");
        IOStrings iOStrings = new IOStrings("string");

        // Random 
        for (int i = 0; i < datalenght; i++)
        {
            Vector4 baba = new Vector4(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            IODataUnit ioDataVector = new IODataUnit(baba);
            iOVectors4.AddData(ioDataVector);
            iOVectors3.AddData(ioDataVector);
            iOVectors2.AddData(ioDataVector);
            iOFloats.AddData(ioDataVector);


            string newString = "";
            for (int j = 0; j < 5; j++)
            {
                newString += _glyphs[Random.Range(0, _glyphs.Length)];
            }
            IODataUnit IODataString = new IODataUnit(newString);
            iOStrings.AddData(IODataString);
        }
        Debug.Log(iOFloats.SerializeData());
        Debug.Log(iOVectors2.SerializeData());
        Debug.Log(iOVectors3.SerializeData());
        Debug.Log(iOVectors4.SerializeData());

        Debug.Log(iOStrings.SerializeData());
    }


}
