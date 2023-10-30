using UnityEngine;

namespace _Games._Scripts.Controllers.Player
{
    public class PlayerController : CharacterController
    {
        [SerializeField] protected GameObject joystickPrefab;

        [SerializeField] protected Transform joystickTf;
        [SerializeField] protected JoystickController joystickController;
        [SerializeField] protected float speed;

        public bool IsMoving => joystickController.IsMoving;

        private void Awake()
        {
            joystickController = Instantiate(joystickPrefab, joystickTf).GetComponent<JoystickController>();
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