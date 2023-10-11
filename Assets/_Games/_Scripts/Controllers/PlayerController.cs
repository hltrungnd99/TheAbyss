using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    // [SerializeField] protected GameObject joystickPrefab;
    // [SerializeField] protected GameObject joystickTf;
    // [SerializeField] protected JoystickController joystickController;
    // [SerializeField] protected float speed;
    //
    // private void Awake()
    // {
    //     // joystickController = Instantiate(joystickPrefab, joystickTf.transform).GetComponent<JoystickController>();
    // }
    // private void FixedUpdate()
    // {
    //     SetupFixUpdate();
    // }
    // protected override void SetupStart()
    // {
    //     base.SetupStart();
    // }
    // protected override void SetupUpdate()
    // {
    //     base.SetupUpdate();
    //    
    //
    // }
    // protected virtual void SetupFixUpdate()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         Move();
    //     }
    //     else
    //     {
    //         Idle();
    //     }
    // }
    //
    // public  void Idle()
    // {
    //     myRig.velocity = Vector3.zero;
    // }
    // public  void Move()
    // {
    //     Vector3 direc = joystickController.Direction;
    //     myRig.velocity = direc * speed * Time.deltaTime;
    //     myRig.rotation = Quaternion.Euler(direc);
    //     float rotate = Mathf.Atan2(direc.x, direc.z) * Mathf.Rad2Deg;
    //     Quaternion quaternion = Quaternion.Euler(0, rotate, 0);
    //     myRig.rotation = quaternion;
    // }
}
