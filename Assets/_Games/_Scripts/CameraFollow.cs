using _Games._Scripts.Controllers.Player;
using UnityEngine;

namespace _Games._Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private PlayerController player;

        [SerializeField] private float speed;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        private Vector3 distanceTargetToCam;
        private Vector3 direction;

        private void Start()
        {
            distanceTargetToCam = transform.position - target.position;
        }

        private void LateUpdate()
        {
            if (player.IsMoving)
            {
                direction = player.DirectionMove;
                speed += Time.deltaTime * 3;
                speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            }
            else
            {
                speed -= Time.deltaTime * 3;
                speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            }

            if (target)
            {
                transform.position = Vector3.Lerp(transform.position,
                    target.position + distanceTargetToCam + direction, Time.deltaTime * speed);
            }
        }
    }
}