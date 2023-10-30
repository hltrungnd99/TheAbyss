using System.Linq;
using UnityEngine;

public class WeaponInChar
{
    public Weapon currentWeaponL;
    public Weapon currentWeaponR;

    // Root parent weapon in model, save in CharacterModel
    private Transform transWeaponShieldL;
    private Transform transWeaponShieldR;

    // Cache parent weapon
    private Transform transPrWeapon;
    private CharacterController myChar;

    public WeaponInChar(Transform transWeaponShieldL2, Transform transWeaponShieldR2,
        CharacterController characterController)
    {
        transWeaponShieldL = transWeaponShieldL2;
        transWeaponShieldR = transWeaponShieldR2;
        myChar = characterController;
    }

    public void MakeNewWeapon(WeaponAsset weaponAsset, bool isRightSide)
    {
        if (isRightSide)
        {
            if (currentWeaponR)
            {
                Object.Destroy(currentWeaponR);
            }

            transPrWeapon = GetTransParentWeapon(transWeaponShieldR, weaponAsset.nameWeapon);
            var isInRootWp = false;
            if (transPrWeapon == null)
            {
                isInRootWp = true;
                transPrWeapon = transWeaponShieldR;
            }

            currentWeaponR = WeaponFactory.instance.LoadAssetWeapon(transPrWeapon, weaponAsset, isInRootWp);
            currentWeaponR.OnInit(weaponAsset, myChar, isRightSide);
            SetTransWeapon(currentWeaponR.transform, weaponAsset, isInRootWp, true);
        }
        else
        {
            if (currentWeaponL)
            {
                Object.Destroy(currentWeaponL);
            }

            transPrWeapon = GetTransParentWeapon(transWeaponShieldL, weaponAsset.nameWeapon);
            var isInRootWp = false;
            if (transPrWeapon == null)
            {
                isInRootWp = true;
                transPrWeapon = transWeaponShieldL;
            }

            currentWeaponL = WeaponFactory.instance.LoadAssetWeapon(transPrWeapon, weaponAsset, isInRootWp);
            currentWeaponL.OnInit(weaponAsset, myChar, isRightSide);
            SetTransWeapon(currentWeaponL.transform, weaponAsset, isInRootWp, false);
        }
    }

    private void SetTransWeapon(Transform transWp, WeaponAsset weaponAsset, bool isInRootWp, bool isRightSide)
    {
        if (isInRootWp)
        {
            if (isRightSide)
            {
                transWp.localPosition = weaponAsset.transformWeaponRBackup.position;
                transWp.localRotation = Quaternion.Euler(weaponAsset.transformWeaponRBackup.rotation);
                transWp.localScale = weaponAsset.transformWeaponRBackup.scale;
            }
            else
            {
                transWp.localPosition = weaponAsset.transformWeaponLBackup.position;
                transWp.localRotation = Quaternion.Euler(weaponAsset.transformWeaponLBackup.rotation);
                transWp.localScale = weaponAsset.transformWeaponLBackup.scale;
            }
        }
        else
        {
            transWp.localPosition = Vector3.zero;
            transWp.localRotation = Quaternion.identity;
            transWp.localScale = Vector3.one;
        }
    }

    private Transform GetTransParentWeapon(Transform transRootWeapon, string nameWeapon)
    {
        return transRootWeapon.Cast<Transform>().FirstOrDefault(child => child.gameObject.name.Contains(nameWeapon));
    }
}