using UnityEngine;

public class AttackStateMachine : IStateMachine
{
    private IAttack iAtk;

    public AttackStateMachine(IAttack iAtk2)
    {
        iAtk = iAtk2;
    }

    public void OnStart(CharacterController cha)
    {
        cha.eCharacterState = ECharacterState.ATTACK;
        if (iAtk != null)
        {
            cha.iAttack = iAtk;
            cha.iAttack.PositiveAtk(cha);
        }
        else
        {
            cha.ChangeStateMachine(new IdleStateMachine());
        }

        var rotation = cha.transform.localEulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        cha.transform.rotation = Quaternion.Euler(rotation);
        
    }

    public void OnExcute(CharacterController cha)
    {
    }

    public void OnExit(CharacterController cha)
    {
    }
}