using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NavigationDebugger : MonoBehaviour
{
    [SerializeField] private InputActionProperty toggleReference;
    [SerializeField]
    private NavMeshAgent agent;

    private LineRenderer _lineRenderer;
    

    private bool _debug = true;


    private void Awake()
    {
        if (!Debug.isDebugBuild)
        {
            Destroy(gameObject);
        }
        _lineRenderer = GetComponent<LineRenderer>();

        toggleReference.action.started += ToggleDebug;
    }
    private void OnDestroy()
    {
        toggleReference.action.started -= ToggleDebug;
    }
    // Update is called once per frame
    void Update()
    {
        if (_debug)
        {
            if (agent.hasPath)
            {
                _lineRenderer.positionCount = agent.path.corners.Length;
                _lineRenderer.SetPositions(agent.path.corners);
                _lineRenderer.enabled = true;
            }
        }
        

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
