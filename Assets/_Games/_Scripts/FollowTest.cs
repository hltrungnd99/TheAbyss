using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTest : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Rigidbody rig;

    // Update is called once per frame
    void Update()
    {
        // var vel = rig.velocity;
        // vel.y = 0;
        //
        // rig.velocity = vel;
        if (agent.enabled && gameObject.activeInHierarchy)
            agent.SetDestination(target.position);
    }
}