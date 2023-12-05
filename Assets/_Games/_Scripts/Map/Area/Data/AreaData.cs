using System;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "ScriptableObjects/AreaData", fileName = "AreaData")]
public class AreaData : ScriptableObject
{
    public AreaElement[] listAreaDatas;

    public AreaElement GetAreaElement(int index)
    {
        if (listAreaDatas != null)
        {
            if (index >= 0 && index < listAreaDatas.Length)
            {
                return listAreaDatas[index];
            }
        }

        return null;
    }
}

[Serializable]
public class AreaElement
{
    public GameObject objAreaPrefab;
    public NavMeshData navMeshArea;
}