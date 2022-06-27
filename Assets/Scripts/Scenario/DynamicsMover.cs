using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicsMover : MonoBehaviour
{
    [SerializeField] Transform XROrigin;
    [SerializeField] Transform beginning;
    [SerializeField] Transform simulation;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform endPoint;
    [Space(30)]
    [SerializeField] private Transform beginningFancyElevator;
    [SerializeField] private Transform simulationFancyOn;
    [SerializeField] private Transform simulationFancyOff;
    [Space(30)]
    [SerializeField] private Transform beginningCheapElevator;
    [SerializeField] private Transform simulationCheapOn;
    [SerializeField] private Transform simulationCheapOff;
    

    public void MoveToBegining(uint hotelType)
    {
        Vector3 teleportationOffset;
        if (hotelType == 0)
        {
            teleportationOffset = beginningFancyElevator.position - spawnPoint.position;
            
        }
        else
        {
            teleportationOffset = beginningCheapElevator.position - spawnPoint.position;
        }

        XROrigin.position += teleportationOffset; // Teleport Player

        beginning.position += new Vector3(0, teleportationOffset.y, 0); // Teleport Beginning dynamics objects
        simulation.position += new Vector3(0, teleportationOffset.y, 0); // Teleport Simulation dynamics objects
    }
    public void MoveToSimulation(uint hotelType, uint lightType)
    {
        float heighOffset = 0;
        if (hotelType == 0)
        {
            if (lightType != 0)
                heighOffset = simulationFancyOff.position.y - simulationFancyOn.position.y;
        }
        else
        {
            if (lightType != 0)
                heighOffset = simulationCheapOff.position.y - simulationCheapOn.position.y;
        }
        XROrigin.position += new Vector3(0, heighOffset, 0); // Teleport Player
        simulation.position += new Vector3(0, heighOffset, 0); // Teleport Simulation dynamics objects
    }
    public void MoveToEnd()
    {
        XROrigin.position = endPoint.position;
    }
}
