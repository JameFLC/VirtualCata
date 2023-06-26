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
    [SerializeField] private Transform beginningElevator;
    [SerializeField] private Transform simulationOn;
    [SerializeField] private Transform simulationOff;
    

    public void MoveToBegining()
    {
        Vector3 teleportationOffset;
        
        teleportationOffset = beginningElevator.position - spawnPoint.position;

        XROrigin.position += teleportationOffset; // Teleport Player

        beginning.position += new Vector3(0, teleportationOffset.y, 0); // Teleport Beginning dynamics objects
        simulation.position += new Vector3(0, teleportationOffset.y, 0); // Teleport Simulation dynamics objects
    }
    public void MoveToSimulation(uint lightType)
    {
        float heighOffset = 0;

        if (lightType != 0)
            heighOffset = simulationOff.position.y - simulationOn.position.y;

        XROrigin.position += new Vector3(0, heighOffset, 0); // Teleport Player
        simulation.position += new Vector3(0, heighOffset, 0); // Teleport Simulation dynamics objects
    }
    public void MoveToEnd()
    {
        XROrigin.position = endPoint.position;
    }
}
