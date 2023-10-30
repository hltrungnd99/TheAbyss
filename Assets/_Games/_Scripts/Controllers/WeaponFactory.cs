using UnityEngine;

public class WeaponFactory : Singleton<WeaponFactory>, IMakeWeapon
{
    private Weapon wpLoadInAsset;
    private Weapon wpIntitate;

    public Weapon LoadAssetWeapon(Transform transPrWeapon, WeaponAsset weaponAsset, bool isInRootWp)
    {
        wpLoadInAsset = Resources.Load<Weapon>(weaponAsset.pathModel);
        // Resources.UnloadAsset(wpLoadInAsset);
        return MakeWeapon(weaponAsset, wpLoadInAsset, transPrWeapon, isInRootWp);
    }

    public Weapon MakeWeapon(WeaponAsset weaponAsset, Weapon wpLoaded, Transform transPr, bool isInRootWp)
    {
        wpIntitate = Instantiate(wpLoaded, transPr);
        // if (wpLoaded) Resources.UnloadAsset(wpLoaded);
        return wpIntitate;
    }
}