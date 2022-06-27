using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLoader : MonoBehaviour
{

    [SerializeField] private Transform simulationFancyOn;
    [SerializeField] private Transform simulationFancyOff;
    [Space]
    [SerializeField] private Transform simulationCheapOn;
    [SerializeField] private Transform simulationCheapOff;



    // Start is called before the first frame update
    void Start()
    {
        UnloadAll(); // Force unloading to prevent scene manipulations rfom breaking the simulation
    }

    public void UnloadAll()
    {
    

        simulationFancyOn.gameObject.SetActive(false);
        simulationFancyOff.gameObject.SetActive(false);

       

        simulationCheapOn.gameObject.SetActive(false);
        simulationCheapOff.gameObject.SetActive(false);
    }
    public void FloorLoading(uint hotelType, uint lightType, bool load)
    {

        if (hotelType == 0)
        {
            if (lightType == 0)
            {
                simulationFancyOn.gameObject.SetActive(load);
               
            }
            else
            {
                simulationFancyOff.gameObject.SetActive(load);

            }
        }
        else
        {
            if (lightType == 0)
            {
                simulationCheapOn.gameObject.SetActive(load);

            }
            else
            {
                simulationCheapOff.gameObject.SetActive(load);

            }
        }
    }
    
}
