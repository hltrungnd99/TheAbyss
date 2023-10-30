using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IAttack
{
    public CharacterController myChar;
    public WeaponAsset weaponAsset;

    public virtual void OnInit(WeaponAsset weaponAsset2, CharacterController characterController,bool isRightSide)
    {
        weaponAsset = weaponAsset2;
        myChar = characterController;
    }

    public virtual void PositiveAtk(CharacterController characterController)
    {
        weaponAsset.PositiveAtk(myChar);
    }

    public virtual void NegativeAtk(CharacterController characterController)
    {
    }

    public virtual void OnHitted(List<CharacterController> lstChars)
    {
    }

    public virtual void OnHitted(Object obj)
    {
    }
}