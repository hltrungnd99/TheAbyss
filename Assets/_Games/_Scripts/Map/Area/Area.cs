using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private int countDie;
    [SerializeField] private float timer;
    [SerializeField] protected DataProvider data;
    [SerializeField] protected CharacterController[] enemys;
    [SerializeField] protected GameObject brigdePrefab;
    [SerializeField] protected Transform pointCenterPos;
    [SerializeField] protected List<Vector3> spawnerEnemyPos;
    protected Brigde myBrigde;
    //public bool canMoveArea => countDie <= 0;
    public int areaID;
    public bool canMoveArea = false;
    public delegate void ChangArea(Area are);
    public event ChangArea changArea;
    private void Start()
    {
        data = FindObjectOfType<DataProvider>();
        OnInitData();
    }
    private void Update()
    {



            if (count == 0)
            {
                canMoveArea = true;
            }
        if (myBrigde == null)
        {
            myBrigde = Instantiate(brigdePrefab).GetComponent<Brigde>();
        }
    }
    public void OnInitData()
    {
        for (int i = 0; i < data.areaData.areaElement.Length; i++)
        {
            if (areaID == data.areaData.areaElement[i].areaID)
            {
                count = data.areaData.areaElement[i].countEnemyNomal;
                enemys = data.areaData.areaElement[i].listEnemy;
            }
        }
        SetupPosEnemy();
        SpawnerEnemy();
    }
    public void SpawnerEnemy()
    {
        int index = count;
        for (int i = 0; i < index; i++)
        {
            Vector3 pos = spawnerEnemyPos[i];
            int rand = Random.Range(0, enemys.Length);
            CharacterController enemy = Instantiate(enemys[rand], pos, Quaternion.identity);
            count--;
        }
    }
    protected void SetupPosEnemy()
    {
        Vector3 pos = RandomPosEnemy();

        for (int i = 0; i < count; i++)
        {
            if (spawnerEnemyPos.Count == 0)
            {
                spawnerEnemyPos.Add(pos);
            }
            if (spawnerEnemyPos.Count >= count) return;
            if (Vector3.Distance(spawnerEnemyPos[i], pos) > 2)
            {
                spawnerEnemyPos.Add(pos);
            }
            else
            {
                i--;
                pos = RandomPosEnemy();
            }
        }
    }
    protected Vector3 RandomPosEnemy()
    {
        float x = Random.Range(pointCenterPos.position.x - 3, pointCenterPos.position.x + 3);
        float z = Random.Range(pointCenterPos.position.z - 3, pointCenterPos.position.z + 3);
        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTags.PLAYER_TAG))
        {
            changArea?.Invoke(this);
        }
    }
}
