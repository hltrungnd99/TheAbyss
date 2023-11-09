using System;
using UnityEngine;
using UnityEditor;


public class StatisticFactory : MonoBehaviour
{
    [SerializeField] float health;
    public float Healh
    {
        get => health;
        set
        {
            if (value <= 0) { value = 0; }
            if (value >= MaxHealth.Value)
            {
                value = MaxHealth.Value;
            }

            health = value;
            // HealthBar.HP = health; 
        }
    }

    [Header("--- STATS (ATTACK TYPE) ---")]
    public Stat Damage;
    public Stat Range;
    public Stat CriticalRate;
    public Stat CriticalDamage;
    public Stat AttackSpeed;
    public Stat Penetrate;
    public Stat Accurate;

    [Header("--- STATS (DEFEND TYPE) ---")]
    public Stat MaxHealth;
    public Stat Recovery;
    public Stat Defense;
    public Stat Evasion;
    public Stat DamageReduction;
    public Stat Block;

    [Header("--- STATS (OTHER TYPE) ---")]
    public Stat MovementSpeed;
    public Stat Vampire;

    public void InitializeBaseStats()
    {
        //[!] Khởi tạo chỉ số cơ bản (Base)
        //[!]Example:
        // Damage = new Stat(baseValue: 10f);
    }

    //[!] Interface function, xử lý sát thương nhận vào
    public float HandlingDamageReceived(StatisticFactory statisticFactory /*float damageReceived, StatModifier criticalDamage = null, StatModifier extraDamage = null, StatModifier reduceDamage = null , Action onHandleComplete = null */)
    {
        //[x] Chưa có dead flag
        // Healh -= CalculateFinalDamageReceived(damageReceived, criticalDamage, extraDamage, reduceDamage);
        // onHandleComplete?.Invoke();

        return CalculateFinalDamageReceived(statisticFactory);
    }

    Stat output = new Stat();
    float finalReceivedDamaged;
    //[!] Tính toán lượng sát thương cuối cùng nhận vào
    float CalculateFinalDamageReceived(StatisticFactory statisticFactory)
    {
        finalReceivedDamaged = CalculateBaseDamageReceived(
            damageReceived: statisticFactory.Damage.Value,
            penetrate: statisticFactory.Penetrate.Value);

        output = new Stat(baseValue: finalReceivedDamaged);

        if (statisticFactory.CriticalRate.Value >= UnityEngine.Random.Range(0, 101))
        {
            output.CalulateCriticalDamage(new StatModifier(statisticFactory.CriticalDamage.Value, STATTYPE.PERCENT));
        }

        output.CalculateReduceDamage(new StatModifier(-DamageReduction.Value, STATTYPE.PERCENT));
        return output.Value < 0 ? 0 : output.Value;
    }

    float CalculateBaseDamageReceived(float damageReceived, float penetrate)
    {
        // Debug.Log($"({damageReceived}*{damageReceived})/({damageReceived}+({Defense.Value}-({Defense.Value}*{penetrate}%)))");
        return (damageReceived * damageReceived) / (damageReceived + (Defense.Value - (Defense.Value * penetrate / 100)));
    }
}

public static class StatisticFactoryExtension
{
    public static Stat CalulateCriticalDamage(this Stat stat, StatModifier criticalDamage)
    {
        return (criticalDamage == null) ? stat : stat.AddModifier(criticalDamage);
    }

    public static Stat CalculateExtraDamage(this Stat stat, StatModifier extraDamage)
    {
        return (extraDamage == null) ? stat : stat.AddModifier(extraDamage);
    }

    public static Stat CalculateReduceDamage(this Stat stat, StatModifier reduceDamage)
    {
        return (reduceDamage == null) ? stat : stat.AddModifier(reduceDamage);
    }
}
