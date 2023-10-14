using System;
using UnityEngine;

namespace _Games._Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed;

        private Vector3 distanceTargetToCam;

        private void Start()
        {
            distanceTargetToCam = transform.position - target.position;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position,
                target.position + distanceTargetToCam + new Vector3(0, 0, 1), Time.deltaTime * speed);
        }
    }
}