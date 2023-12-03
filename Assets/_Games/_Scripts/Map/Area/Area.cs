using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] protected int countEnemyInArea;
    [SerializeField] protected bool isSideArea;
    [SerializeField] protected Transform sideAreaSpawnPos;
    [SerializeField] protected Transform enemySpawnPos;
    [SerializeField] protected List<int> listWeightInArea;
    [SerializeField] protected List<EnemyController> listEnemysWeight;
    [SerializeField] protected List<EnemyController> listEnemySpawnFromArea;
    public Vector3 areaPosition = new Vector3();
    public Quaternion areaRotation = new Quaternion();
    public int areaIDData;
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
    protected void GetData()
    {
        int index = DataProvider.instance.DataArea.dataInArea.Length;
        for (int i = 0; i < index; i++)
        {
            if (areaIDData != DataProvider.instance.DataArea.dataInArea[i].areaID) continue;
            isSideArea = DataProvider.instance.DataArea.dataInArea[i].isSideArea;
            countEnemyInArea = DataProvider.instance.DataArea.dataInArea[i].countEnemyNomalInArea;
            listWeightInArea = DataProvider.instance.DataArea.dataInArea[i].weightEnemyInArea;
            listEnemysWeight = DataProvider.instance.DataArea.dataInArea[i].listEnemySpawnInArea;
        }
        CheckIsSideArea();
    }
    protected void CheckIsSideArea()
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
        float ranX = Random.Range(enemySpawnPos.transform.position.x - 5, enemySpawnPos.transform.position.x + 5);
        float ranZ = Random.Range(enemySpawnPos.transform.position.z - 5, enemySpawnPos.transform.position.z + 5);
        Vector3 pos = new Vector3(ranX, 0, ranZ);
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
    public virtual void SpawnEnemy()
    {
        for (int i = 0; i < countEnemyInArea; i++)
        {
            Vector3 pos = GetPosEnemy();
            EnemyController go = SpawnerEnemyArea.Instance.SpawnerEnemyInArea(listWeightInArea, listEnemysWeight, pos, Quaternion.identity);
            listEnemySpawnFromArea.Add(go);
        }
        //SetUpPosEnemy(0);
    }
    protected virtual void ReturnSpawnerEnemy()
    {
        for (int i = 0; i < listEnemySpawnFromArea.Count; i++)
        {

            //Enemy in DeActive;
            SpawnerEnemyArea.Instance.DeSpawnerEnemyInArea(listEnemySpawnFromArea[i].gameObject, listEnemySpawnFromArea[i].poolType);
        }
        listEnemySpawnFromArea.Clear();
    }
}
