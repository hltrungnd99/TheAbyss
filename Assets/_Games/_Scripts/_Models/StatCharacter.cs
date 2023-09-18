using System;

[Serializable]
public class StatCharacter
{
    public StatCharacterATK statCharacterATK;
    public StatCharacterDMF statCharacterDMF;
    public StatCharacterOther statCharacterOther;
}

[Serializable]
public class StatCharacterATK
{
    public float minATK;
    public float maxATK;
    public float rangeATK;
    public float criticalRate;
    public float criticalDamage;
    public float ASPD;
    public float penetrate;
    public float accurate;
}

[Serializable]
public class StatCharacterDMF
{
    public float HP;
    public float recovery;
    public float def;
    public float evasion;
    public float damageReduction;
}

[Serializable]
public class StatCharacterOther
{
    public float MSPD;
    public float vamp;
}

[Serializable]
public class StatusATK
{
    public EStatusATKType eStatusATKType;
    public float damage;
}