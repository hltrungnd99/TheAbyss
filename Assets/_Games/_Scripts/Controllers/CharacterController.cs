using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody myRig;
    [SerializeField] protected StatsCharacterBase statsCharacterBase;
    [SerializeField] protected Animator animatorCharacter;
    [SerializeField] protected string myStatBase;

    private string currentStateAnim;
    protected bool isCanMove;

    public StatCharacter statCharacter;


    private void Start()
    {
        // if set up data
         statCharacter = new StatCharacter();
         statCharacter.Clone(SetupTypeStat());

        SetupStart();
    }

    private void Update()
    {

        SetupUpdate();
    }
    protected StatCharacter SetupTypeStat()
    {
        for (int i = 0; i < statsCharacterBase.statCharacter.Length; i++)
        {
            if (myStatBase.Contains(statsCharacterBase.statCharacter[i].characterStat))
            {
                return statsCharacterBase.statCharacter[i];
            }
        }
        return null;
    }
    protected virtual void SetupStart()
    {
        ChangAnim(MyConstan.PLAYER_ANIM_IDLE);
    }

    protected virtual void SetupUpdate()
    {

    }
    public virtual void Idle()
    {
        ChangAnim(MyConstan.PLAYER_ANIM_IDLE);
    }

    public virtual void Move()
    {
        ChangAnim(MyConstan.PLAYER_ANIM_RUN);
    }
    public virtual void Attack()
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
