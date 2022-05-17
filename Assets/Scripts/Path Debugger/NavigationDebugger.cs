using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NavigationDebugger : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float updateDelay = 0.2f;

    private LineRenderer _lineRenderer;
    

    private bool _debug = false;
    private float _lastTime = 0;

    private void Awake()
    {
        if (!Debug.isDebugBuild)
        {
            Destroy(gameObject);
        }
        _lineRenderer = GetComponent<LineRenderer>();

        EventManager.instance.OnTogglePathDebug += ToggleDebug;

        _lineRenderer.enabled = false; 
    }
    private void OnDestroy()
    {
        EventManager.instance.OnTogglePathDebug -= ToggleDebug;
    }
    // Update is called once per frame
    void Update()
    {
        if (_debug && Time.time >= _lastTime + updateDelay)
        {
            _lastTime = Time.time;
            if (agent.hasPath)
            {
                DisplayAgentPath();
            }
        }
    }

    private void DisplayAgentPath()
    {
        _lineRenderer.positionCount = agent.path.corners.Length;
        _lineRenderer.SetPositions(agent.path.corners);
        _lineRenderer.enabled = true;
    }

    public void ToggleDebug()
    {
        if (_debug) _lineRenderer.enabled = false;
        else _lineRenderer.enabled = true;

        _debug = !_debug;
    }
    private void ToggleDebug(InputAction.CallbackContext context)
    {
        if (_debug) _lineRenderer.enabled = false;
        else _lineRenderer.enabled = true;

        _debug = !_debug;
    }
}
