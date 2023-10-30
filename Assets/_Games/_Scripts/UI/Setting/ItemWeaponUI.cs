using UnityEngine;
using UnityEngine.UI;

public class ItemWeaponUI : MonoBehaviour
{
    [SerializeField] private Text txtName;

    private WeaponAsset wp;

    public void OnInit(WeaponAsset weaponAsset)
    {
        wp = weaponAsset;
        txtName.text = weaponAsset.nameWeapon;
    }

    public void MakeWeapon()
    {
        // if (SettingUI.instance.togglePlayer.isOn)
        // {
        //     LevelController.instance.player.weaponInChar.MakeNewWeapon(wp, SettingUI.instance.toggleRightHand);
        // }
        // else
        // {
        //     for (int i = 0; i < LevelController.instance.listEnemy.Count; i++)
        //     {
        //         LevelController.instance.listEnemy[i].weaponInChar
        //             .MakeNewWeapon(wp, SettingUI.instance.toggleRightHand);
        //     }
        // }
    }
}