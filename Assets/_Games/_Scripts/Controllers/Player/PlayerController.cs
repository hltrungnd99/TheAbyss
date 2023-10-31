using System;
using UnityEngine;

namespace _Games._Scripts.Controllers.Player
{
    public class PlayerController : CharacterController
    {
        [SerializeField] protected GameObject joystickPrefab;

        [SerializeField] protected Transform joystickTf;
        [SerializeField] protected JoystickController joystickController;
        [SerializeField] protected float speed;

        private CharacterController enemyDead;

        public bool IsMoving => joystickController.IsMoving;

        protected override void SetupAwake()
        {
            base.SetupAwake();

            joystickController = Instantiate(joystickPrefab, joystickTf).GetComponent<JoystickController>();
            this.RegisterEventListener(EventName.ENEMY_DEAD, EventDead);
        }

        protected override void SetupDestroy()
        {
            base.SetupDestroy();

            this.RemoveEventListener(EventName.ENEMY_DEAD, EventDead);
        }

        protected override void SetupUpdate()
        {
            base.SetupUpdate();

            if (eCharacterState == ECharacterState.DIE) return;
            if (Input.GetMouseButton(0))
            {
                ChangeStateMachine(new MoveStateMachine());
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ChangeStateMachine(new IdleStateMachine());
            }
        }

        protected override void EventDead(Component arg1, object[] arg2)
        {
            base.EventDead(arg1, arg2);

            if (arg2.Length > 0)
            {
                enemyDead = (CharacterController)arg2[0];
                if (enemyDead)
                {
                    if (enemyDead && enemyDead.CompareTag(ConstTags.ENEMY_TAG))
                    {
                        CancelWarningAttack(enemyDead);
                    }
                }
            }
        }

        protected override void Dead()
        {
            base.Dead();

            this.PostEvent(EventName.PLAYER_DEAD, new object[] { this });
        }

        public override void ExcuteMove()
        {
            if (IsMoving)
            {
                base.ExcuteMove();
                directionMove = joystickController.Direction;
                transform.position =
                    Vector3.MoveTowards(transform.position, transform.position + directionMove,
                        Time.deltaTime * speed);
                myRig.rotation = Quaternion.Euler(directionMove);
                float rotate = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg;
                Quaternion quaternion = Quaternion.Euler(0, rotate, 0);
                myRig.rotation = quaternion;
            }
        }
    }
}