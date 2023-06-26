using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLoader : MonoBehaviour
{
    [SerializeField] private Transform simulationOn;
    [SerializeField] private Transform simulationOff;

    void Start()
    {
        //UnloadAll(); // Force unloading to prevent scene manipulations rfom breaking the simulation
    }

    public void UnloadAll()
    {
        simulationOn.gameObject.SetActive(false);
        simulationOff.gameObject.SetActive(false);
    }
    public void FloorLoading(uint lightType, bool load)
    {

        if (lightType == 0)
        {
            simulationOn.gameObject.SetActive(load);

        }
        else
        {
            simulationOff.gameObject.SetActive(load);

        }
    }
    
}
