using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Animator : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetFloat("Speed", agent.velocity.magnitude / agent.speed);   
    }
}
