using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AreaData", fileName = "AreaData")]  
public class AreaData : ScriptableObject
{
    public AreaElement[] areaElement;
}
[System.Serializable]
public class AreaElement
{
    public int count;
    public int areaID;
    public CharacterController[] listEnemy;
}

