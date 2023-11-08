using UnityEngine;

[CreateAssetMenu(fileName = "SwordAsset", menuName = "ScriptableObjects/Weapon/SwordAsset")]
public class SwordAsset : WeaponAsset
{
    [SerializeField] private string paramAnim;

    #region IAttack

    public override void PositiveAtk(CharacterController myChar)
    {
        base.PositiveAtk(myChar);

        if (!myChar.IsCanChaseTarget())
        {
            return;
        }

        myChar.transform.LookAt(myChar.transCharTarget);
        myChar.ChangeAnim(paramAnim);
    }

    #endregion
}