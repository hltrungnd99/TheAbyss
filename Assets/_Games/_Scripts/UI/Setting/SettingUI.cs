using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : Singleton<SettingUI>
{
    [SerializeField] private List<WeaponAsset> listWeapon=new List<WeaponAsset>();
    [SerializeField] private ItemWeaponUI itemWeaponUIPrefab;
    [SerializeField] private Transform transContentItem;

    public Toggle togglePlayer;
    public Toggle toggleRightHand;
}
