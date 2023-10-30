using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    public void PositiveAtk(CharacterController myChar);
    public void NegativeAtk(CharacterController myChar);
    public void OnHitted(List<CharacterController> lstChars);
    public void OnHitted(Object obj);
}