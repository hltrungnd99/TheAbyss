using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Area : MonoBehaviour
{
    [SerializeField] protected bool isSideArea;
    [SerializeField] protected Transform sideAreaSpawnPos;
    [SerializeField] protected Transform enemySpawnPos;
    [SerializeField] protected List<EnemyController> listEnemySpawnFromArea = new();
    [SerializeField] protected EnemyZone enemyZone;

    [Space] [Header("data")] public LevelElement levelElement;
    public AreaData areaData;
    public int areaIndex;

    private NavMeshData _navMeshData;

    // public Vector3 areaPosition = new Vector3();
    // public Quaternion areaRotation = new Quaternion();
    // public int areaIdData;
    // public int areaIDCheckPool;
    // public PoolType poolType;

    void Start()
    {
        SpawnEnemy();
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    SpawnArea();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    DeActiveArea();
        //}
    }

    private void GetData(LevelElement levelElement2)
    {
        levelElement = levelElement2;
        isSideArea = levelElement.isSideArea;
        CheckIsSideArea();
    }

    private void CheckIsSideArea()
    {
        sideAreaSpawnPos.gameObject.SetActive(isSideArea);
    }

    protected virtual Vector3 GetPosEnemy()
    {
        var ranX = Random.Range(enemySpawnPos.transform.position.x - 5, enemySpawnPos.transform.position.x + 5);
        var ranZ = Random.Range(enemySpawnPos.transform.position.z - 5, enemySpawnPos.transform.position.z + 5);
        var pos = new Vector3(ranX, 0, ranZ);
        return pos;
    }

    /// <summary>
    /// QuynhTV_Check Enemy impact together
    /// </summary>
    //protected virtual void SetUpPosEnemy(int index)
    //{
    //    for (int i = index; i < listEnemySpawnFromArea.Count; i++)
    //    {
    //        for (int j = i + 1; j < listEnemySpawnFromArea.Count; j++)
    //        {
    //            if (Vector3.Distance(listEnemySpawnFromArea[i].transform.position, listEnemySpawnFromArea[j].transform.position) >= 2f) continue;
    //            RandomPosDistance(listEnemySpawnFromArea[j].transform.position);
    //            SetUpPosEnemy(j);
    //        }
    //    }
    //}
    //protected virtual Vector3 RandomPosDistance(Vector3 pos)
    //{
    //    float ranX = Random.Range(-10, 10);
    //    float ranZ = Random.Range(-10, 10);
    //    int ran = Random.Range(0, 2);
    //    Debug.LogError(ran);
    //    if (ran == 0)
    //    {
    //        return pos += new Vector3(ranX, 0, ranZ);
    //    }
    //    else
    //    {
    //        return pos -= new Vector3(ranX, 0, ranZ);
    //    }
    //}
    public virtual void ActiveArea(LevelElement areaInLevel, int areaIndex2, AreaData areaData2)
    {
        areaData = areaData2;
        areaIndex = areaIndex2;
        GetData(areaInLevel);
        ActiveNavMesh();
        SpawnEnemy();
    }

    private void ActiveNavMesh()
    {
        if (areaData.navMeshArea == null)
        {
            Debug.LogError("NavMeshData is not assigned!");
            return;
        }

        _navMeshData = Instantiate(areaData.navMeshArea);
        _navMeshData.position = transform.position;
        _navMeshData.rotation = transform.rotation;

        NavMesh.AddNavMeshData(_navMeshData);
    }

    public virtual void DeActiveArea()
    {
        ReturnSpawnerEnemy();
    }

    protected virtual void SpawnEnemy()
    {
        for (var i = 0; i < levelElement.countEnemyNomalInArea; i++)
        {
            var pos = GetPosEnemy();
            var go = SpawnerEnemyArea.Instance.SpawnerEnemyInArea(levelElement.weightEnemyInArea,
                levelElement.listEnemySpawnInArea, pos, Quaternion.identity);
            enemyZone.AddEnemyToZone(go);
            listEnemySpawnFromArea.Add(go);
        }
    }

    protected virtual void ReturnSpawnerEnemy()
    {
        for (var i = 0; i < listEnemySpawnFromArea.Count; i++)
        {
            //Enemy in DeActive;
            SpawnerEnemyArea.Instance.DeSpawnerEnemyInArea(listEnemySpawnFromArea[i].gameObject,
                listEnemySpawnFromArea[i].poolType);
        }

        listEnemySpawnFromArea.Clear();
    }
}