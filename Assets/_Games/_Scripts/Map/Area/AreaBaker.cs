using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaBaker : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> listNaveMesh = new();

    void Start()
    { 
        for (var i = 0; i < listNaveMesh.Count; i++)
        {
            listNaveMesh[i].RemoveData();
            listNaveMesh[i].BuildNavMesh();
        }
    }
}