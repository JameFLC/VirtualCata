using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC_DestinationSwitcher : MonoBehaviour
{
    [SerializeField] private float updateDelay = 3f;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();



    private NavMeshAgent _agent;

    private float _lastTime = 0;
    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _lastTime -= updateDelay;
    }
    int count = 0;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _lastTime + updateDelay)
        {
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint()
    {
        _lastTime = Time.time;
        _agent.destination = waypoints[count % waypoints.Count].position;
        ++count;
    }
}
