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
    [SerializeField] protected GameObject brigdePos;
    private Brigde myBrigde;
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
        timer += Time.deltaTime;
        if (timer > 2f && count > 0)
        {
            SpawnerEnemy();
            timer = 0;
            if (count == 0)
            {
                canMoveArea = true;
            }
        }
        if (myBrigde == null)
        {
            myBrigde = Instantiate(brigdePrefab, brigdePos.transform.position,Quaternion.identity).GetComponent<Brigde>();


        }
    }
    public void OnInitData()
    {
        for (int i = 0; i < data.areaData.areaElement.Length; i++)
        {
            if (areaID == data.areaData.areaElement[i].areaID)
            {
                count = data.areaData.areaElement[i].count;
                enemys = data.areaData.areaElement[i].listEnemy;
            }
        }
    }
    public void SpawnerEnemy()
    {
        float posX = Random.Range(transform.position.x-5, transform.position.x + 5);
        float posZ = Random.Range(transform.position.z - 5, transform.position.z + 5);
        Vector3 pos = new Vector3(posX, 0, posZ);
        int rand = Random.Range(0, enemys.Length);
        CharacterController enemy = Instantiate(enemys[rand], pos, Quaternion.identity);
        count--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(MyConstan.PLAYER_TAG))
        {
            Debug.LogError("chec");
            changArea?.Invoke(this);
        }
    }
}
