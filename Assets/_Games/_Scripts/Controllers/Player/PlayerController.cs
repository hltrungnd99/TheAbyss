using System.Collections.Generic;
using UnityEngine;

namespace _Games._Scripts.Controllers.Player
{
    public class PlayerController : CharacterController
    {
        [SerializeField] protected GameObject joystickPrefab;

        [SerializeField] protected Transform joystickTf;
        [SerializeField] protected JoystickController joystickController;
        [SerializeField] protected float speed;

        [SerializeField] private List<EnemyController> listEnemys = new List<EnemyController>();

        private EnemyController enemy;
        private EnemyController enemyTarget;

        public bool IsMoving => joystickController.IsMoving;

        private void Awake()
        {
            joystickController = Instantiate(joystickPrefab, joystickTf).GetComponent<JoystickController>();
            this.RegisterEventListener(EventName.CALLBACK_ANIM_1, ActiveColAtk);
        }

        protected override void SetupOnDestroy()
        {
            base.SetupOnDestroy();

            this.RemoveEventListener(EventName.CALLBACK_ANIM_1, ActiveColAtk);
        }

        protected override void SetupUpdate()
        {
            base.SetupUpdate();

            if (Input.GetMouseButton(0))
            {
                Move();
            }
            else
            {
                Idle();
            }

            if (listEnemys.Count > 0)
            {
                float minDistance = 999f;
                int indexPre = -1;
                for (int i = 0; i < listEnemys.Count; i++)
                {
                    var disntace = Vector3.Distance(transform.position, listEnemys[i].transform.position);
                    if (disntace < minDistance)
                    {
                        minDistance = disntace;
                        if (indexPre >= 0)
                        {
                            listEnemys[indexPre].ActiveTarget(false);
                        }

                        indexPre = i;
                        listEnemys[i].ActiveTarget(true);

                        enemyTarget = listEnemys[i];
                    }
                }
            }
            else
            {
                enemyTarget = null;
            }
        }

        protected override void Move()
        {
            if (IsMoving && eCharacterState == ECharacterState.IDLE)
            {
                base.Move();
                directionMove = joystickController.Direction;
                transform.position =
                    Vector3.MoveTowards(transform.position, transform.position + directionMove, Time.deltaTime * speed);
                myRig.rotation = Quaternion.Euler(directionMove);
                float rotate = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg;
                Quaternion quaternion = Quaternion.Euler(0, rotate, 0);
                myRig.rotation = quaternion;
            }
        }

        protected override void Idle()
        {
            base.Idle();

            if (listEnemys.Count > 0)
            {
                // GetNearestEnemy();

                if (eCharacterState == ECharacterState.IDLE)
                {
                    Attack<PlayerController, EnemyController>(this, new List<EnemyController>() { enemyTarget });
                }
            }
        }

        #region Attack

        public override void WarningAttack(Collider other)
        {
            base.WarningAttack(other);

            enemy = other.GetComponent<EnemyController>();
            if (enemy && !listEnemys.Contains(enemy))
            {
                listEnemys.Add(enemy);
                if (eCharacterState == ECharacterState.IDLE)
                {
                    Attack<PlayerController, EnemyController>(this);
                }
            }
        }

        public override void CancelWarningAttack(Collider other)
        {
            base.CancelWarningAttack(other);
            enemy = other.GetComponent<EnemyController>();
            if (enemy && listEnemys.Contains(enemy))
            {
                listEnemys.Remove(enemy);
            }
        }

        #endregion
    }
}