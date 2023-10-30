using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    public CharacterController player;
    public List<CharacterController> listEnemy = new List<CharacterController>();
}