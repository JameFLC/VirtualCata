using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class IOHelpRecorder : IODataRecorder
{
    [SerializeField] NPC_Grabbable_Help targetHelp;
    private float _helpingTime = 0;
    private float _stopHelpingTime = 0;
    //private float _lastHelpingTime = 0;

    
    void Start()
    {
        data = new IOStrings(dataName);
    }

    public void Grabbed()
    {
        _helpingTime = Time.time;
    }
    public void Ungrapped()
    { 
        SaveHelpData();
    }
    void SaveHelpData()
    {
        string itemString = " Helping from [" + _helpingTime.ToString("F" + 2, CultureInfo.InvariantCulture) + "] to [" + Time.time.ToString("F" + 2, CultureInfo.InvariantCulture) + "]";
        Debug.Log(itemString);
        IODataUnit currentData = new IODataUnit(itemString);
        data.AddData(currentData);
    }
}
