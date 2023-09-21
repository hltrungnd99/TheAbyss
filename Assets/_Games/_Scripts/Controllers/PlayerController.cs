using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    protected override void SetupUpdate()
    {
        base.SetupUpdate();

//#if UNITY_EDITOR

//        if (Input.GetKey(KeyCode.W))
//        {
//            directionMove.z = 1;
//        }

//        if (Input.GetKey(KeyCode.S))
//        {
//            directionMove.z = -1;
//        }

//        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
//        {
//            directionMove.z = 0;
//        }

//        if (Input.GetKey(KeyCode.A))
//        {
//            directionMove.x = -1;
//        }

//        if (Input.GetKey(KeyCode.D))
//        {
//            directionMove.x = 1;
//        }

//        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
//        {
//            directionMove.x = 0;
//        }

//        if (Input.GetKeyDown(KeyCode.K))
//        {
//            Attack();
//        }

//        Rotate();
//        Move();

//#endif
    }
}
