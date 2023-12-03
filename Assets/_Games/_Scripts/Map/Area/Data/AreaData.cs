using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AreaData", fileName ="AreaData")]
public class AreaData : ScriptableObject
{
    public AreaElement[] dataInArea; 
}
[System.Serializable]
public class AreaElement
{
    public bool isSideArea;
    public int countEnemyNomalInArea;
    public int areaID;
    public List<int> weightEnemyInArea;
    public List<EnemyController> listEnemySpawnInArea; 
}

