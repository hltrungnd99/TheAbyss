using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] protected GameObject joystickPrefab;

    [SerializeField] protected GameObject joystickTf;
    [SerializeField] protected JoystickController joystickController;
    [SerializeField] protected float speed;

    // private void Awake()
    // {
    //     joystickController = Instantiate(joystickPrefab, joystickTf.transform).GetComponent<JoystickController>();
    // }

    protected override void SetupFixedUpdate()
    {
        base.SetupFixedUpdate();

        directionMove = joystickController.Direction;
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + directionMove, Time.deltaTime * speed);
        myRig.rotation = Quaternion.Euler(directionMove);
        float rotate = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg;
        Quaternion quaternion = Quaternion.Euler(0, rotate, 0);
        myRig.rotation = quaternion;
    }
}