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
        }
        else
        {
            Destroy(this);
        }
    }
    public void SetSimulatedProfileID(uint profileID)
    {
        _simulatedProfileID = profileID;
        Debug.Log("Selected Simulated profile updated to " + profileID);
    }
    public void SetSimulatedProfileID(int profileID)
    {
        if (profileID < 0)
        {
            Debug.LogError("Selected Simulated profile should nt be negative");
            return;
        }
        _simulatedProfileID = (uint)profileID;
        Debug.Log("Selected Simulated profile updated to " + profileID);
    }
    public uint GetSimulatedProfileID()
    {
        return _simulatedProfileID;
    }
}
