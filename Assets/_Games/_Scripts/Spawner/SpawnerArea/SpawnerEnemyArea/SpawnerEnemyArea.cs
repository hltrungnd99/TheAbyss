using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyArea : Spawner
{
    protected int minWeight = 0;
    protected int maxWeight = 100;
    public static SpawnerEnemyArea Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public virtual EnemyController SpawnerEnemyInArea(List<int> weight, List<EnemyController> listEnemyWeigh,Vector3 pos,Quaternion rot)
    {
        EnemyController enemy = GetEnemyFromWeight(weight, listEnemyWeigh);
        GameObject go = Pooling.instance.GetPool(pos, rot, enemy.poolType);
        return go.GetComponent<EnemyController>();
    }
    public virtual void DeSpawnerEnemyInArea(GameObject go,PoolType type)
    {
        Pooling.instance.ReturnPool(go,type);
    }

    protected virtual EnemyController GetEnemyFromWeight(List<int> weight,List<EnemyController> listEnemyWeigh)
    {
        EnemyController enemy = null;
        int weightMax = 0;
        for (int i = 0; i <listEnemyWeigh.Count; i++)
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
