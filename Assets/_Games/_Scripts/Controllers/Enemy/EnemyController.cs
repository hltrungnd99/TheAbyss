using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterController
{
    [SerializeField] protected NavMeshAgent navMeshEnemy;
    [SerializeField] protected GameObject objTarget;

    public void ActiveTarget(bool isActive)
    {
        objTarget.SetActive(isActive);
    }
}