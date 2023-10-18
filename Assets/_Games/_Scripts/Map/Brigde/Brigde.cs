using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brigde : MonoBehaviour
{
    public BaseMap baseMap;
    public int brideID;


    private void Start()
    {
        baseMap = FindObjectOfType<BaseMap>();
        brideID = baseMap.currentArea.areaID;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(MyConstan.PLAYER_TAG))
        {
            if (baseMap.currentArea.canMoveArea && brideID == baseMap.currentArea.areaID)
            {
                Debug.LogError("compare");
                int areaID = ++baseMap.currentAreaID;
                Area are = baseMap.SpawnerArea(areaID);
            }
        }
    }
}
