using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    // Class containing a vector4 to contain all type of float values and a string for not numeral values
    // The make it possible to have daughter daughter classes of IOData have different datatypes
    public class IODataUnit
    {

        private Vector4 dataNumber = Vector4.zero;
        private string dataString = "";
        public IODataUnit(float param)
        {
            dataNumber.x = param;
        }
        public IODataUnit(Vector2 param)
        {
            dataNumber.x = param.x;
            dataNumber.y = param.y;
        }
        public IODataUnit(Vector3 param)
        {
            dataNumber.x = param.x;
            dataNumber.y = param.y;
            dataNumber.z = param.z;
        }
        public IODataUnit(Vector4 param)
        {
            dataNumber = param;
        }
        public IODataUnit(string param)
        {
            dataString = param;
        }
        public float GetFloat()
        {
            return dataNumber.x;
        }
        public Vector2 GetVector2()
        {
            return new Vector2(dataNumber.x,dataNumber.y);
        }
        public Vector3 GetVector3()
        {
            return new Vector3(dataNumber.x, dataNumber.y,dataNumber.z);
        }
        public Vector4 GetVector4()
        {
            return dataNumber;
        }
        public string GetString()
        {
            return dataString;
        }
}