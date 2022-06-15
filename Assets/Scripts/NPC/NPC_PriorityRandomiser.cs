using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_PriorityRandomiser : MonoBehaviour
{
    [SerializeField] private Vector2 priorityRange = new Vector2(10, 50);
    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.avoidancePriority = (int) Random.Range(priorityRange.x, priorityRange.y);
    }

    
}
