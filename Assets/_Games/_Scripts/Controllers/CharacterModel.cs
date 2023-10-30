using System.Collections.Generic;
using _Games._Scripts;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    public CharacterController myChar;
    public CallbackAnim callbackAnim;
    public Animator animatorCharacter;

    public Transform transWeaponShieldL;
    public Transform transWeaponShieldR;

    public WeaponInChar weaponInChar;

    public void OnInit(CharacterController myChar2)
    {
        myChar = myChar2;
        weaponInChar = new WeaponInChar(transWeaponShieldL, transWeaponShieldR, myChar);

        var isRightSide = true;

        callbackAnim.RemoveAllCallback();
        for (int i = 0; i < myChar.listWeaponInit.Count; i++)
        {
            if (myChar.listWeaponInit[i] != null)
            {
                weaponInChar.MakeNewWeapon(myChar.listWeaponInit[i], isRightSide);
                myChar.listWeaponInit[i].OnInit();
                isRightSide = false;
            }
        }
    }
}