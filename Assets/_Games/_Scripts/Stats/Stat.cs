using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class Stat
{
    public float BaseValue;
    public virtual float Value
    {
        get
        {
            if (isDirty || BaseValue != lastBaseValue)
            {
                isDirty = false;
                ResetValue();
            }

            return value;
        }
    }

    [SerializeField] protected float value;
    // [SerializeField] protected float chaos = 0f;
    protected float lastBaseValue = /*float.MinValue*/ 0f;

    protected bool isDirty = true;
    [SerializeField] protected List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public Stat()
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public Stat(float baseValue/* , float chaosPercent = 0f */) : this()
    {
        BaseValue = baseValue;
        // if (chaosPercent != 0f)
        // {
        //     chaos = MathF.Round(baseValue * UnityEngine.Random.Range(-chaosPercent, chaosPercent), 2);
        // }
    }

    public void ResetValue()
    {
        lastBaseValue = BaseValue;
        value = CalculateFinalValue();
        if (value < 0) { value = 0; }
    }

    public void SetDirty() { isDirty = true; }

    public Stat AddModifier(StatModifier modifier)
    {
        isDirty = true;
        statModifiers.Add(item: modifier);

        return this;
    }

    public void AddOneWayModifier(StatModifier modifier)
    {
        if (!statModifiers.Contains(item: modifier))
        {
            isDirty = true;
            statModifiers.Add(item: modifier);
        }
    }

    public Stat Clear(float newBaseValue)
    {
        isDirty = true;
        statModifiers.Clear();
        BaseValue = newBaseValue;

        return this;
    }

    public void ClearModifier()
    {
        if (statModifiers.Count > 0)
        {
            isDirty = true;
            statModifiers.Clear();
        }
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        if (statModifiers.Remove(modifier))
        {
            isDirty = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier modifier = statModifiers[i];

            switch (modifier.Type)
            {
                case STATTYPE.FLAT:
                    finalValue += statModifiers[i].Value;
                    break;

                case STATTYPE.PERCENT:
                    sumPercentAdd += modifier.Value;
                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != STATTYPE.PERCENT)
                    {
                        finalValue += sumPercentAdd / 100f * BaseValue;
                    }
                    break;

                    // case STATTYPE.PERCENTMULTIPLE: 
                    //     finalValue *= 1 + modifier.Value;
                    //     break;
            }
        }

        return MathF.Round(finalValue /* + chaos */, 2);
    }
}

[Serializable]
public class StatModifier
{
    [HideInInspector] public string Name;

    public float Value { get; private set; }
    [HideInInspector] public STATTYPE Type = STATTYPE.FLAT;
    [HideInInspector] public STAT Stat = STAT.NONE;
    // public readonly int Order = 0;

    string source;

    public StatModifier(float value, STATTYPE type, STAT stat)
    {
        Value = value;
        Type = type;
        Stat = stat;
    }

    public StatModifier(float value, STATTYPE type, STAT stat, string source)
    {
        Value = value;
        Type = type;
        Stat = stat;

        PaintNamespace(source);
    }

    public StatModifier(StatModifier statModifier)
    {
        Value = statModifier.Value;
        Stat = statModifier.Stat;
        Type = statModifier.Type;
        Name = statModifier.Name;

        source = statModifier.source;
    }

    public StatModifier(float value, StatModifier statModifier)
    {
        Value = value;
        Stat = statModifier.Stat;
        Type = statModifier.Type;
        Name = statModifier.Name;

        source = statModifier.source;
        PaintNamespace(source);
    }


    public void AddValue(float value)
    {
        Value += value;
        RepaintNamespace();
    }

    public void RepaintNamespace()
    {
        SetNamespace();
    }

    public void PaintNamespace(string source)
    {
        this.source = source;
        SetNamespace();
    }

    void SetNamespace()
    {
#if UNITY_EDITOR
        Name = Stat == STAT.NONE ? $"+({Value}{(Type == STATTYPE.FLAT ? "" : "%")}) [{source}]" : $"+({Value}{(Type == STATTYPE.FLAT ? "" : "%")}) [{Stat}][{source}]";
#endif
    }

    public StatModifier(float value, STATTYPE type) : this(value, type, STAT.NONE) { }
}

public enum STAT
{
    ATK, HP, DEF, PARRY, CRITRATE, CRITDMG, SPEED, ATKSPEED, COST, NONE
}

public enum STATTYPE
{
    FLAT, PERCENT,
}
