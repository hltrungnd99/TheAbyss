using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Area : MonoBehaviour
{
    [SerializeField] protected bool isSideArea;
    [SerializeField] protected Transform sideAreaSpawnPos;
    [SerializeField] protected Transform enemySpawnPos;
    [FormerlySerializedAs("areaElement")] [SerializeField] protected LevelElement levelElement;
    [SerializeField] protected List<EnemyController> listEnemySpawnFromArea = new();
    [SerializeField] protected EnemyZone enemyZone;

    public Vector3 areaPosition = new Vector3();
    public Quaternion areaRotation = new Quaternion();
    public int areaIndex;
    public int areaIdData;
    public int areaIDCheckPool;
    public PoolType poolType;

    //void Start()
    //{
    //    SpawnArea();
    //}
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

    private void GetData()
    {
        var index = DataProvider.instance.dataLevel.dataInArea.Length;
        for (var i = 0; i < index; i++)
        {
            if (areaIndex != DataProvider.instance.dataLevel.dataInArea[i].areaIndex) continue;
            levelElement = DataProvider.instance.dataLevel.dataInArea[i];
            isSideArea = levelElement.isSideArea;
        }

        CheckIsSideArea();
    }

    private void CheckIsSideArea()
    {
        if (isSideArea)
        {
            sideAreaSpawnPos.gameObject.SetActive(true);
        }
        else
        {
            sideAreaSpawnPos.gameObject.SetActive(false);
        }
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
    public virtual void ActiveArea()
    {
        GetData();
        SpawnEnemy();
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
        //SetUpPosEnemy(0);
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