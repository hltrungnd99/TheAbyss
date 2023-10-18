using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 pos;
    [SerializeField] private Transform targetPos;
    private void Start()
    {
        pos = targetPos.position - transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = targetPos.position - pos;
        transform.position = newPos;
    }
}
