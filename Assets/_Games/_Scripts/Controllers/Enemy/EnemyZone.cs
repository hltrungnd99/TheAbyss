using System.Collections.Generic;
using _Games._Scripts.Controllers.Player;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    [SerializeField] private List<EnemyController> listEnemyInZone = new();

    private PlayerController player;

    public void AddEnemyToZone(EnemyController enemyController)
    {
        if (!listEnemyInZone.Contains(enemyController))
        {
            listEnemyInZone.Add(enemyController);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTags.PLAYER_TAG))
        {
            player = other.GetComponentInParent<PlayerController>();
            if (player)
            {
                Debug.LogError("add");
                for (var i = 0; i < listEnemyInZone.Count; i++)
                {
                    listEnemyInZone[i].AddPlayerInZone(player);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ConstTags.PLAYER_TAG))
        {
            player = other.GetComponentInParent<PlayerController>();
            if (player)
            {
                for (var i = 0; i < listEnemyInZone.Count; i++)
                {
                    listEnemyInZone[i].RemovePlayerInZone(player);
                }
            }
        }
    }
}