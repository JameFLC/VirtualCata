using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningStates : MonoBehaviour
{
    [SerializeField] private float openingAngle = 0;

    private HingeJoint _hingeJoint;
    private JointSpring _defaultSpring;


    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _defaultSpring = _hingeJoint.spring;


    }
    public void SetDoorOpening(float openingForce)
    {
        JointSpring spring = _defaultSpring;
        spring.spring = openingForce;
        spring.targetPosition = openingAngle;
        _hingeJoint.spring = spring;
    }
    public void SetDoorClosing(float openingForce)
    {
        JointSpring spring = _defaultSpring;
        spring.spring = openingForce;
        _hingeJoint.spring = spring;
    }
    public void SetDoorNeutral()
    {
        _hingeJoint.spring = _defaultSpring;
    }
    
}
