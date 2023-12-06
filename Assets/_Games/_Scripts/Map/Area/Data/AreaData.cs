using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "ScriptableObjects/AreaData", fileName = "AreaData")]
public class AreaData : ScriptableObject
{
    public Area objAreaPrefab;
    public NavMeshData navMeshArea;
}