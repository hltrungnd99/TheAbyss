using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BattleSimulator : MonoBehaviour
{
    public StatisticFactory Attacker, Defender;

    [Space(16)]
    public float Output;
    public void Attack()
    {
        Output = Defender.HandlingDamageReceived(statisticFactory: Attacker);
    }
}


[CustomEditor(typeof(BattleSimulator))]
public class BattleSimulatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("SIMULATE ATTACKER ATTACK"))
        {
            ((BattleSimulator)target).Attack();
        }
    }
}
