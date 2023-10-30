using UnityEngine;

public class Sword : Weapon
{
    private MeshCollider colWp;
    public int countHit;
    public int numHit;

    public override void OnInit(WeaponAsset weaponAsset2, CharacterController characterController, bool isRightSide)
    {
        base.OnInit(weaponAsset2, characterController, isRightSide);

        colWp = GetComponent<MeshCollider>();

        myChar.characterModel.callbackAnim.AddCallback(0, ActiveHitted);
        myChar.characterModel.callbackAnim.AddCallback(1, DeactiveHitted);
        if (isRightSide)
            myChar.characterModel.callbackAnim.AddCallbackEndAnim(EndAnimAttack);
    }

    private void EndAnimAttack()
    {
        myChar.ChangeStateMachine(new IdleStateMachine());
    }

    private void DeactiveHitted()
    {
        colWp.enabled = false;
    }

    private void ActiveHitted()
    {
        colWp.enabled = true;
    }

    public override void PositiveAtk(CharacterController characterController)
    {
        if (myChar.IsCanChaseTarget())
        {
            countHit = 0;
            base.PositiveAtk(characterController);
        }
    }

    public override void OnHitted(Object obj)
    {
        base.OnHitted(obj);

        if (countHit < numHit && myChar.charTarget &&
            myChar.charTarget.colRecieveDamage.GetInstanceID() == obj.GetInstanceID())
        {
            Debug.LogError(myChar.gameObject.name + " damaged " + myChar.charTarget.gameObject.name);
            countHit++;
            myChar.Damage(myChar.charTarget);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTags.ENEMY_TAG) || other.CompareTag(ConstTags.PLAYER_TAG))
        {
            OnHitted(other);
        }
    }
}