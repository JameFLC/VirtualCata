using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_PriorityRandomiser : MonoBehaviour
{
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.avoidancePriority = (int) Random.Range(1, 100);
    }

    
}
