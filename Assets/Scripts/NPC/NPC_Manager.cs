using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    [SerializeField] List<NPC_DestinationSwitcher> NPCList = new List<NPC_DestinationSwitcher>();
    [SerializeField] Transform hurtNPCParent;
    [SerializeField] Transform NPCParent;
    [Space(20)]
    [SerializeField] Transform leftExit;
    [SerializeField] Transform rigthExit;
    [Space]
    [SerializeField] List<Transform> panicWaypoints;
    
    [SerializeField] float panicDefaultWaitTime = 6f;
    [SerializeField] float panicRandomltWaitTime = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        ToggleNPCs(false, false);
    }

    public void ToggleNPCs(bool enabled, bool hurtNPC)
    {
        ToggleNormalNPCs(enabled);
        ToggleHurtNPC(enabled && hurtNPC);
    }


    private void ToggleNormalNPCs(bool enabled)
    {
        NPCParent.gameObject.SetActive(enabled);
    }
    private void ToggleHurtNPC(bool enabled)
    {
        hurtNPCParent.gameObject.SetActive(enabled);
    }
    public void RemoveNPCs(uint percent)
    {
        int numberToRemove = NPCList.Count - Mathf.RoundToInt(NPCList.Count*(100.0f / percent));
        if (numberToRemove > 0)
        {
            for (int i = 1; i >= numberToRemove; i++)
            {
                int ID = Mathf.Clamp((i / numberToRemove) + Random.Range(-1, 1), 0, NPCList.Count - 1);
                GameObject NPCToDelete = NPCList[ID].gameObject;
                NPCList.RemoveAt(ID);
                Destroy(NPCToDelete);
            }
        }
        
    }

    public int GetNPCCount()
    {
        return NPCList.Count;
    }
    public void SetupNPCExits(uint evacuationDirection, uint evacuationType)
    {
        if (evacuationType != 1)
        {
            switch (evacuationDirection)
            {
                default:
                case 0: // Default waypoints on Each NPCs
                    break;
                case 1: // Left
                    SetSingleWaypoint(leftExit);
                    break;
                case 2: // Right
                    SetSingleWaypoint(rigthExit);
                    break;
                case 3: // Random
                    SetRandomExitWaypoint();
                    break;
            }
            return;
        }
        SetRandomPanicWaypoint();
    }

    private void SetSingleWaypoint(Transform waypoint)
    {
        List<Transform> waypontList = new List<Transform>();
        waypontList.Add(waypoint);
        foreach (NPC_DestinationSwitcher NPC in NPCList)
        {
            NPC.evacuationWaypoints = waypontList;
        }
    }
    private void SetRandomExitWaypoint()
    {         
        foreach (NPC_DestinationSwitcher NPC in NPCList)
        {
            List<Transform> waypontList = new List<Transform>();
            Transform waypoint = (Random.Range(0, 1) > 0.5) ? leftExit : rigthExit;
            waypontList.Add(waypoint);
            NPC.evacuationWaypoints = waypontList;
        }
    }
    private void SetRandomPanicWaypoint()
    {
        foreach (NPC_DestinationSwitcher NPC in NPCList)
        {
            FisherYatesWaypointShuffle(panicWaypoints); // Shuffle 
            NPC.evacuationWaypoints = panicWaypoints;
            NPC.updateDelay = panicDefaultWaitTime + Random.Range(0, panicRandomltWaitTime);
        }
    }
             //================================================================//
             //===================Fisher_Yates_CardDeck_Shuffle====================//
             //================================================================//

    /// With the Fisher-Yates shuffle, first implemented on computers by Durstenfeld in 1964, 
    ///   we randomly sort elements. This is an accurate, effective shuffling method for all array types.

    public List<Transform> FisherYatesWaypointShuffle(List<Transform> waypointList)
    {

        System.Random _random = new System.Random();

        Transform myGO;

        int n = waypointList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = waypointList[r];
            waypointList[r] = waypointList[i];
            waypointList[i] = myGO;
        }

        return waypointList;
    }
}
