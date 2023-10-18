using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Games._Scripts.Controllers.Ability.Warrior.DoubleSword.Scripts
{
    [CreateAssetMenu(fileName = "NormalAttackDoubleSword",
        menuName = "Ability/Warrior/DoubleSword/NormalAttackDoubleSword", order = 0)]
    public class NormalAttackDoubleSword : NormalAttack
    {
        public CharacterController target;
        public List<Collider> lstColsWeapon = new();
        public int numHit;

        private bool isCanContactCol;

        private void OnEnable()
        {
            Debug.LogError("OnEnable");
        }

        private void OnDisable()
        {
            Debug.LogError("OnDisable");
        }

        public override void Attack<T1, T2>(T1 characterController, List<T2> lstEnemy = null)
        {
            base.Attack(characterController, lstEnemy);

            if (IsCanAttack())
            {
                characterController.ChangeAnim(paramAnim);
                if (lstEnemy != null && lstEnemy.Count > 0)
                {
                    target = lstEnemy[0];
                }
                else
                {
                    target = null;
                }

                characterController.callbackAnim.AddCallback1(ActiveContactCols);
                characterController.callbackAnim.AddCallback2(DeactiveContactCols);
            }
        }

        private void ActiveContactCols()
        {
            isCanContactCol = true;
        }

        private void DeactiveContactCols()
        {
            isCanContactCol = false;
        }

        private void GetWeapons(CharacterController character)
        {
            if (lstColsWeapon.Count <= 0 || lstColsWeapon.Any(x => x == null))
            {
                lstColsWeapon.Clear();
                lstColsWeapon = character.transform.GetComponentsInChildren<Collider>()
                    .Where(x => x.CompareTag($"Weapon")).ToList();
            }
        }

        public override void Hitted<T1, T2>(T1 damager, List<T2> characterHitted = null)
        {
            base.Hitted(damager, characterHitted);

            if (characterHitted != null && target != null && characterHitted.Contains(target as T2))
            {
                Debug.LogError("Hitted: " + target.gameObject.name);

                damager.Damage<T2>(target as T2);
            }
        }
    }
}