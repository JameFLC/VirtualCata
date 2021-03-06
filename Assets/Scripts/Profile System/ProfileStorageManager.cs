using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileStorageManager : MonoBehaviour
{

    public static ProfileStorageManager instance;

    private uint _simulatedProfileID = 1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //Rest of Awake
            Debug.Log("New simulated profile selected is " + instance._simulatedProfileID);
        }
        else
        {
            Debug.Log("Current Simulated profile selected is " + instance._simulatedProfileID);
        }
    }
    public void SetSimulatedProfileID(uint profileID)
    {
        instance._simulatedProfileID = profileID;
        Debug.Log("Selected Simulated profile updated to " + profileID);
    }
    public void SetSimulatedProfileID(int profileID)
    {
        if (profileID < 0)
        {
            Debug.LogError("Selected Simulated profile should nt be negative");
            return;
        }
        instance._simulatedProfileID = (uint)profileID;
        Debug.Log("Selected Simulated profile updated to " + profileID);
    }
    public uint GetSimulatedProfileID()
    {
        return instance._simulatedProfileID;
    }
}
