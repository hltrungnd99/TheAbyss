using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelData", fileName = "LevelData")]
public class LevelData : ScriptableObject
{
    public LevelElement[] dataInArea;
}

[System.Serializable]
public class LevelElement
{
    public bool isSideArea;
    public int countEnemyNomalInArea;
    public int areaId;
    public Vector3 areaPosition;
    public Vector3 areaRotation;
    public List<int> weightEnemyInArea;
    public List<EnemyController> listEnemySpawnInArea;
}