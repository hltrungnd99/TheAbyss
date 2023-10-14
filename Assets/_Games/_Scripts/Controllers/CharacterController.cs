using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody myRig;
    [SerializeField] protected Animator animatorCharacter;

    protected Vector3 directionMove = Vector3.zero;
    protected bool isCanMove;

    private string currentStateAnim;

    private void Start()
    {
        SetupStart();
    }

    private void Update()
    {
        SetupUpdate();
    }

    private void FixedUpdate()
    {
        SetupFixedUpdate();
    }

    protected virtual void SetupStart()
    {
        ChangAnim(MyConstan.PLAYER_ANIM_IDLE);
    }

    protected virtual void SetupUpdate()
    {
    }

    protected virtual void SetupFixedUpdate()
    {
    }

    public void ChangAnim(string anim)
    {
        if (anim != currentStateAnim)
        {
            animatorCharacter.ResetTrigger(currentStateAnim);
            currentStateAnim = anim;
            animatorCharacter.SetTrigger(currentStateAnim);
        }
    }
}