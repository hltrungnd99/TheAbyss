using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody myRig;

    [SerializeField] private StatsCharacterBase statsCharacterBase;
    [SerializeField] private Animator animatorCharacter;

    private Vector3 directionMove = Vector3.zero;
    private bool isCanMove;
    private string currentStateAnim;

    public StatCharacter statCharacter;

    private void Start()
    {
        statCharacter = statsCharacterBase.statCharacter;

        SetupStart();
    }

    private void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.W))
        {
            directionMove.z = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            directionMove.z = -1;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            directionMove.z = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            directionMove.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            directionMove.x = 1;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            directionMove.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }

        Rotate();
        Move();

#endif
    }

    protected virtual void SetupStart()
    {

    }

    protected virtual void SetupUpdate()
    {

    }

    private void Move()
    {
        if (directionMove.magnitude < 0.05f)
        {
            if (currentStateAnim != "idle")
            {
                currentStateAnim = "idle";
                animatorCharacter.SetTrigger("idle");
            }
            myRig.velocity = Vector3.zero;
        }
        else
        {
            myRig.velocity = directionMove * statCharacter.statCharacterOther.MSPD;

            if (directionMove.magnitude < 0.6f)
            {
                if (currentStateAnim != "walk")
                {
                    currentStateAnim = "walk";
                    animatorCharacter.SetTrigger("walk");
                }
            }
            else
            {
                if (currentStateAnim != "run")
                {
                    currentStateAnim = "run";
                    animatorCharacter.SetTrigger("run");
                }
            }
        }

    }

    private void Rotate()
    {
        if (directionMove.magnitude >= 0.05f)
        {
            var angle = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * 10);
        }
    }

    private void Attack()
    {
        animatorCharacter.SetTrigger("attack");
    }

    protected void ChangeState()
    {

    }
}
