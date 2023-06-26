using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class ControllerObjectMovement : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private float controllerMass = 20.0f;
    [Header("PID")]
    [SerializeField] private float moveFrequency = 50.0f;
    [SerializeField] private float moveDamping = 0.5f;
    [SerializeField] private float rotFrequency = 100.0f;
    [SerializeField] private float rotDamping = 0.9f;




    private Transform followTarget;
    private Rigidbody RB;

    //private bool isToutchingAnything = false;


    // Start is called before the first frame update
    void Start()
    {
        // Variable setup
        followTarget = followObject.transform;
        RB = GetComponent<Rigidbody>();
        // Rigidbody setup
        RB.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        RB.interpolation = RigidbodyInterpolation.Interpolate;
        RB.mass = controllerMass;
        RB.maxAngularVelocity = Mathf.Infinity;

    }

    private void FixedUpdate()
    {
        //physicsMove();
        PIDMovement();
        PIDRotation();
    }
    // from https://en.wikipedia.org/wiki/PID_controller
    private void PIDMovement()
    {
        float kp = (6f * moveFrequency) * (6f * moveFrequency) * 0.25f;
        float kd = 4.5f * moveFrequency * moveDamping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Vector3 force = (followTarget.position - transform.position) * ksg - ( RB.velocity * kdg);
        RB.AddForce(force, ForceMode.Acceleration);
    }
    private void PIDRotation()
    {
        float kp = (6f * rotFrequency) * (6f * rotFrequency) * 0.25f;
        float kd = 4.5f * rotFrequency * rotDamping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Quaternion q = followTarget.rotation * Quaternion.Inverse(transform.rotation);
        if (q.w < 0)
        {
            q.x = -q.x;
            q.y = -q.y;
            q.z = -q.z;
            q.w = -q.w;
        }
        q.ToAngleAxis(out float angle, out Vector3 axis);
        axis.Normalize();
        axis *= Mathf.Deg2Rad;
        Vector3 torque = ksg * axis * angle - RB.angularVelocity * kdg;
        RB.AddTorque(torque, ForceMode.Acceleration);
    }
}
