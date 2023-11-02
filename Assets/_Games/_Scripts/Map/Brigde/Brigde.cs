using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brigde : MonoBehaviour
{
    public BaseMap baseMap;
    public int brideID;
    [SerializeField] protected List<int> enableIDArea = new List<int>();

    private void Start()
    {
        baseMap = FindObjectOfType<BaseMap>();
        brideID = baseMap.currentArea.areaID;
        transform.SetParent(baseMap.brigdePos[brideID]);
        transform.localPosition = Vector3.zero;
        enableIDArea.Add(brideID);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTags.PLAYER_TAG))
        {
            if (baseMap.currentArea.canMoveArea && brideID == baseMap.currentArea.areaID)
            {
                int areaID = ++baseMap.currentAreaID;
                Area are = baseMap.SpawnerArea(areaID);
                if (enableIDArea.Count < 2) enableIDArea.Add(areaID);

            }
            EnableArea();
        }
    }
    public void EnableArea()
    {
        List<Area> areEnable = baseMap.myAreaEnables;
        if (areEnable.Count < 3) return;
        for(int i = 0; i < areEnable.Count; i++)
        {
            if (areEnable[i].areaID != enableIDArea[0]&& areEnable[i].areaID != enableIDArea[1])
            {
                areEnable[i].gameObject.SetActive(false);
            }
            else
            {
                areEnable[i].gameObject.SetActive(true);
            }
        }
    }
}