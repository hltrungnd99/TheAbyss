using System.Collections.Generic;
using UnityEngine;

namespace _Games._Scripts.Controllers.Ability
{
    public class AbilityBase : ScriptableObject
    {
        public virtual bool IsCanAttack()
        {
            return true;
        }

        public virtual void Attack<T1, T2>(T1 characterController, List<T2> lstEnemy = null)
            where T1 : CharacterController
            where T2 : CharacterController
        {
        }

        public virtual void Hitted<T1, T2>(T1 damager, List<T2> characterHitted = null)
            where T1 : CharacterController
            where T2 : CharacterController
        {
        }
    }
}