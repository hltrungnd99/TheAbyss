using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyArea : Spawner
{
    private int minWeight = 0;
    private int maxWeight = 100;
    public static SpawnerEnemyArea Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public virtual EnemyController SpawnerEnemyInArea(List<int> weight, List<EnemyController> listEnemyWeigh,
        Vector3 pos, Quaternion rot)
    {
        var enemyInWeight = GetEnemyFromWeight(weight, listEnemyWeigh);
        var go = Pooling.instance.GetPool(pos, rot, enemyInWeight.poolType);
        var enemy = go.GetComponent<EnemyController>();
        enemy.transform.position = pos;
        StartCoroutine(enemy.IESetDestination(pos));
        return enemy;
    }

    public virtual void DeSpawnerEnemyInArea(GameObject go, PoolType type)
    {
        Pooling.instance.ReturnPool(go, type);
    }

    protected virtual EnemyController GetEnemyFromWeight(List<int> weight, List<EnemyController> listEnemyWeigh)
    {
        EnemyController enemy = null;
        int weightMax = 0;
        for (int i = 0; i < listEnemyWeigh.Count; i++)
        {
            int index = GetWeight(weight[i]);
            if (index > weightMax)
            {
                weightMax = index;
                enemy = listEnemyWeigh[i];
            }
        }

        return enemy;
    }

    protected virtual int GetWeight(int weight)
    {
        int rand = Random.Range(minWeight, maxWeight);
        return weight += rand;
    }
}