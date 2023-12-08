using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerArea : Spawner
{
    public List<Area> listAllArea = new();

    public void LoadAreas(LevelData levelData)
    {
        NavMesh.RemoveAllNavMeshData();
        for (var i = 0; i < levelData.dataInArea.Length; i++)
        {
            var areaInLevel = levelData.dataInArea[i];
            var areaParent = new GameObject("Area_" + i);
            areaParent.transform.SetParent(transform);
            areaParent.transform.position = areaInLevel.areaPosition;
            areaParent.transform.rotation = Quaternion.Euler(areaInLevel.areaRotation);
            SpawnArea(areaInLevel, areaParent.transform, i);
        }

        DeActiveAllArea();
    }

    protected virtual void DeActiveAreaID(int id)
    {
        for (var i = 0; i < listAllArea.Count; i++)
        {
            if (listAllArea[i].levelElement.areaId != id) continue;
            listAllArea[i].DeActiveArea();
        }
    }

    protected virtual void DeActiveAreaIndex(int index)
    {
        for (var i = 0; i < listAllArea.Count; i++)
        {
            if (listAllArea[i].areaIndex != index) continue;
            listAllArea[i].DeActiveArea();
        }
    }

    protected virtual void SpawnArea(LevelElement areaInLevel, Transform areaParent, int areaIndex)
    {
        StartCoroutine(IELoadArea((areaData) =>
        {
            var area = Instantiate(areaData.objAreaPrefab, areaParent);
            listAllArea.Add(area);
            SetArea(areaInLevel, area, areaIndex, areaData);
        }));
    }

    private IEnumerator IELoadArea(Action<AreaData> callback = null)
    {
        var request = Resources.LoadAsync<AreaData>(Const.pathArea + GameData.instance.currentLevel);
        yield return request;
        callback?.Invoke(request.asset as AreaData);
    }

    protected virtual void SetArea(LevelElement areaInLevel, Area area, int areaIndex, AreaData areaData)
    {
        area.transform.localPosition = Vector3.zero;
        area.transform.localRotation = Quaternion.identity;
        area.ActiveArea(areaInLevel, areaIndex, areaData);
    }

    protected virtual void DeActiveAllArea()
    {
        for (var i = 0; i < listAllArea.Count; i++)
        {
            if (listAllArea[i].areaIndex != 0)
            {
                DeActiveAreaID(listAllArea[i].levelElement.areaId);
            }
        }
    }
}