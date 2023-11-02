using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMap : MonoBehaviour
{
    public Area[] area;
    public Transform[] areaPos;
    public Transform[] brigdePos;
    public int currentAreaID;
    public Area currentArea;
    public List<Area> myAreaEnables = new List<Area>();

    private void Start()
    {
        Area are = SpawnerArea(currentAreaID);
        are.changArea += ChangArea;
    }
    public Area SpawnerArea(int areaID)
    {
        for(int i = 0; i < myAreaEnables.Count; i++)
        {
            if(areaID == myAreaEnables[i].areaID)
            {
                myAreaEnables[i].gameObject.SetActive(true);
                ChangArea(myAreaEnables[i]);
                return myAreaEnables[i];
            }
        }
        Area are = Instantiate(area[areaID], areaPos[areaID].transform);
        myAreaEnables.Add(are);
        currentArea = are;
        are.changArea += ChangArea;
        return are;
    }
    protected void ChangArea(Area area)
    {
        currentArea = area;
        currentAreaID = area.areaID;
    }
}
