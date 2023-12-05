using System.Collections.Generic;
using UnityEngine;

public class SpawnerArea : Spawner
{
    [SerializeField] protected int countArea;
    [SerializeField] protected int startIDArea;
    [SerializeField] protected List<Area> listAreaSpawnInGame = new();
    [SerializeField] protected List<Transform> listTransformAreaInGame = new();
    public List<Area> listAllArea = new();

    private void Start()
    {
        OnInit();
    }

    protected virtual void OnInit()
    {
        for (var i = 0; i < countArea; i++)
        {
            SpawnArea(listTransformAreaInGame[i].position, listTransformAreaInGame[i].rotation, PoolType.Area, i + 1);
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

    protected virtual void SpawnArea(Vector3 pos, Quaternion rot, PoolType type, int id)
    {
        var go = Pooling.instance.GetPool(pos, rot, type);
        var area = go.GetComponent<Area>();
        SetArea(id, area);
    }

    protected virtual void SetArea(int i, Area area)
    {
        listAreaSpawnInGame.Add(area);
        area.areaIDData = i;
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