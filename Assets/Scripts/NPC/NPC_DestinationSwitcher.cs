using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC_DestinationSwitcher : MonoBehaviour
{
    public float updateDelay = 3f;
    public List<Transform> defaultWaypoints = new List<Transform>();
    public List<Transform> evacuationWaypoints = new List<Transform>();


    private NavMeshAgent _agent;
    int _normalCount = 0;
    int _evacuationCount = 0;
    private float _lastTime = 0;
    private bool _evacuation = false;
    private void Awake()
    {
        EventManager.instance.OnStartEvacuation += Evacuate;
        _agent = GetComponent<NavMeshAgent>();
        _lastTime -= updateDelay;
    }

    

    private void OnDestroy()
    {
        EventManager.instance.OnStartEvacuation -= Evacuate;

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _lastTime + updateDelay)
        {
            _lastTime = Time.time;
            if (_evacuation)
            {
                GoToNextEvacuationWaypoint();
                return;
            }
            GoToNextNormalWaypoint();
        }
    }
    private void Evacuate()
    {
        _evacuation = true;
        GoToNextEvacuationWaypoint();
    }
    private void GoToNextNormalWaypoint()
    {  
        if (defaultWaypoints.Count > 0) 
            _agent.destination = defaultWaypoints[_normalCount % defaultWaypoints.Count].position;
        ++_normalCount;
    }
    private void GoToNextEvacuationWaypoint()
    {
        if (evacuationWaypoints.Count > 0) 
            _agent.destination = evacuationWaypoints[_evacuationCount % evacuationWaypoints.Count].position;
        ++_evacuationCount;
    }
}
