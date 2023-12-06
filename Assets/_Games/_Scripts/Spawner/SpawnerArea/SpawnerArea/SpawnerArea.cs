using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerArea : Spawner
{
    [SerializeField] protected int startIDArea;
    [SerializeField] protected List<Area> listAreaSpawnInGame = new();
    [SerializeField] protected List<Transform> listTransformAreaInGame = new();
    public List<Area> listAllArea = new();

    public void LoadAreas(LevelData levelData)
    {
        for (var i = 0; i < levelData.dataInArea.Length; i++)
        {
            var areaInLevel = levelData.dataInArea[i];
            var areaParent = new GameObject("Area_" + areaInLevel.areaIndex);
            areaParent.transform.SetParent(transform);
            areaParent.transform.position = areaInLevel.areaPosition;
            areaParent.transform.rotation = Quaternion.Euler(areaInLevel.areaRotation);
            SpawnArea(areaInLevel, areaParent.transform);
            SetDataAreaOnit(i);
        }

        listAllArea = new List<Area>(listAreaSpawnInGame);
        DeActiveAllArea();
    }

    protected virtual void ActiveArea(int id)
    {
        for (var i = 0; i < listAllArea.Count; i++)
        {
            if (listAllArea[i].areaIDCheckPool != id) continue;
            var are = listAllArea[i];
            are.gameObject.SetActive(true);
            SetArea(id, are);
        }
    }

    protected virtual void DeActiveArea(int id)
    {
        for (var i = 0; i < listAllArea.Count; i++)
        {
            if (listAllArea[i].areaIDCheckPool != id) continue;
            listAllArea[i].DeActiveArea();
            Pooling.instance.ReturnPool(listAllArea[i].gameObject, listAllArea[i].poolType);
            listAreaSpawnInGame.Remove(listAllArea[i]);
        }
    }

    protected virtual void SpawnArea(LevelElement areaInLevel, Transform areaParent)
    {
        StartCoroutine(IELoadArea((areaData) =>
        {
            var area = Instantiate(areaData.objAreaPrefab, areaParent);
            SetArea(areaIndex, area);
        }));
    }

    private IEnumerator IELoadArea(Action<AreaData> callback = null)
    {
        var request = Resources.LoadAsync<AreaData>(Const.pathArea + GameData.instance.currentLevel);
        yield return request;
        callback?.Invoke(request.asset as AreaData);
    }

    protected virtual void SetArea(int i, Area area)
    {
        listAreaSpawnInGame.Add(area);
        area.areaIndex = i;
        area.ActiveArea();
    }

    protected virtual void DeActiveAllArea()
    {
        for (var i = 0; i < listAllArea.Count; i++)
        {
            if (listAllArea[i].areaIDCheckPool != startIDArea)
            {
                DeActiveArea(listAllArea[i].areaIDCheckPool);
            }
        }
    }

    protected virtual void SetDataAreaOnit(int index)
    {
        listAreaSpawnInGame[index].areaIDCheckPool = index + 1;
        listAreaSpawnInGame[index].areaPosition = listAreaSpawnInGame[index].transform.position;
        listAreaSpawnInGame[index].areaRotation = listTransformAreaInGame[index].transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeActiveAllArea();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DeActiveArea(2);
            DeActiveArea(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiveArea(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ActiveArea(2);
        }
    }
}