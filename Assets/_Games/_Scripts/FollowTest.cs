using UnityEngine;
using UnityEngine.AI;

public class FollowTest : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    void Update()
    {
        if (agent.enabled && gameObject.activeInHierarchy)
            agent.SetDestination(target.position);
    }
}