using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationProfileHandler : MonoBehaviour
{
    [Space(10)]
    [SerializeField] Transform fancyHotelSpawnPoint;
    [SerializeField] Transform cheapHotelSpawnPoint;
    [Space]
    [SerializeField] Transform fancyHotelEvacuationLightSpawnPoint;
    [SerializeField] Transform cheapHotelEvacuationLightSpawnPoint;
    [Space]
    [SerializeField] Transform fancyHotelEvacuationNoLightSpawnPoint;
    [SerializeField] Transform cheapHotelEvacuationNoLightSpawnPoint;

    [Space]
    [Space]
    [SerializeField] Transform XROrigin;


    private void Start()
    {

    }

}
