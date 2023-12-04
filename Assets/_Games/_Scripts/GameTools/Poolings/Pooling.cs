using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : Singleton<Pooling>
{
    [System.Serializable]
    public class Pool
    {
        public int count;
        public bool isMore;
        public PoolType poolType;
        public GameObject poolPrefab;
        public Transform parent;
    }
    public List<Pool> listPools = new List<Pool>();
    public Dictionary<PoolType, Queue<GameObject>> dicPools = new Dictionary<PoolType, Queue<GameObject>>();

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < listPools.Count; i++)
        {
            Queue<GameObject> gameObjects = new Queue<GameObject>();
            PoolType type = listPools[i].poolType;
            for (int j = 0; j < listPools[i].count; j++)
            {
                GameObject go = Instantiate(listPools[i].poolPrefab, listPools[i].parent);
                gameObjects.Enqueue(go);
                go.gameObject.SetActive(false);
            }
            dicPools.Add(type, gameObjects);
        }
    }
    public GameObject GetPool(Vector3 position, Quaternion rotate, PoolType type)
    {
        GameObject go = null;
        for (int i = 0; i < listPools.Count; i++)
        {
            if (listPools[i].poolType != type) continue;
            Queue<GameObject> que = new Queue<GameObject>();
            if (!dicPools.ContainsKey(type))
            {
                go = SpawnPool(listPools[i].poolPrefab, listPools[i].parent, position, rotate);
                que.Enqueue(go);
                dicPools.Add(type, que);
            }
            else
            {
                if (dicPools[type].Count > 0)
                {
                    Queue<GameObject> queee = new Queue<GameObject>();
                    dicPools.TryGetValue(listPools[i].poolType, out queee);
                    go = queee.Dequeue();
                    go.gameObject.SetActive(true);
                    go.transform.position = position;
                    go.transform.rotation = rotate;
                }
                else
                {
                    if (listPools[i].isMore)
                    {
                        go = SpawnPool(listPools[i].poolPrefab, listPools[i].parent, position, rotate);
                        que.Enqueue(go);
                    }
                }
            }
        }
        return go;
    }
    public void ReturnPool(GameObject go, PoolType type)
    {
        go.gameObject.SetActive(false);
        dicPools[type].Enqueue(go);
    }
    protected GameObject SpawnPool(GameObject prefab, Transform parent, Vector3 position, Quaternion rotate)
    {
        GameObject go = null;
        go = Instantiate(prefab, parent);
        go.transform.position = position;
        go.transform.rotation = rotate;
        return go;
    }
}
public enum PoolType
{
    None = 0,
    Enemy1,
    Enemy2,
    Enemy3,

    Area

}
