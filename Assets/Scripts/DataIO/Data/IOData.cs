using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Base class of custom serialisable data
    // The class has a name and should have a liste of variables of compatible type with IODataTypes
    public abstract class IOData
    {
        protected string _name;

        public IOData(string name)
        {
            _name = name;
        }

        public abstract void AddData(IODataUnit data);

        public abstract string SerializeData();
    }
