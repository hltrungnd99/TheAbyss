using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class WeaponAsset : ScriptableObject, IAttack
{
    public string pathModel;
    public string nameWeapon;
    public TransformWeaponBackup transformWeaponRBackup;
    public TransformWeaponBackup transformWeaponLBackup;

    public virtual void OnInit()
    {
    }

    public virtual void PositiveAtk(CharacterController myChar)
    {
    }

    public virtual void NegativeAtk(CharacterController myChar)
    {
    }

    public virtual void OnHitted(List<CharacterController> lstChars)
    {
    }

    public virtual void OnHitted(Object obj)
    {
    }
}

[Serializable]
public class TransformWeaponBackup
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}