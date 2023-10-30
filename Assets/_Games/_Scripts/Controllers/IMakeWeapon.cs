using UnityEngine;

public interface IMakeWeapon
{
    public Weapon LoadAssetWeapon(Transform transPrWeapon, WeaponAsset weaponAsset, bool isInRootWp);
}