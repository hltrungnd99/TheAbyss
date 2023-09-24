using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "StatCharacterBase", menuName = "ScriptableObjects/StatsCharacterBase")]
public class StatsCharacterBase : ScriptableObject
{
    public StatCharacter statCharacter;

    public void Clone(StatsCharacterBase statsCharacterBase2)
    {
        statCharacter.Clone(statsCharacterBase2.statCharacter);
    }
}

