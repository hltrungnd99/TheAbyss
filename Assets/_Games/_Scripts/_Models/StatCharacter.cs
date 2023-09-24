using System;
using System.Collections.Generic;
using System.Reflection;

[Serializable]
public class StatCharacter
{
    public StatCharacterATK statCharacterATK;
    public StatCharacterDMF statCharacterDMF;
    public StatCharacterOther statCharacterOther;

    public void Clone(StatCharacter statCharacter2)
    {
        this.statCharacterATK.Clone(statCharacter2.statCharacterATK);
        this.statCharacterDMF.Clone(statCharacter2.statCharacterDMF);
        this.statCharacterOther.Clone(statCharacter2.statCharacterOther);
    }
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

    public void Clone(StatCharacterATK statCharacterATK2)
    {
        this.minATK = statCharacterATK2.minATK;
        this.maxATK = statCharacterATK2.maxATK;
        this.rangeATK = statCharacterATK2.rangeATK;
        this.criticalRate = statCharacterATK2.criticalRate;
        this.criticalDamage = statCharacterATK2.criticalDamage;
        this.ASPD = statCharacterATK2.ASPD;
        this.penetrate = statCharacterATK2.penetrate;
        this.accurate = statCharacterATK2.accurate;
    }
}

[Serializable]
public class StatCharacterDMF
{
    public float HP;
    public float recovery;
    public float def;
    public float evasion;
    public float damageReduction;

    public void Clone(StatCharacterDMF statCharacterDMF2)
    {
        this.HP = statCharacterDMF2.HP;
        this.recovery = statCharacterDMF2.recovery;
        this.def = statCharacterDMF2.def;
        this.evasion = statCharacterDMF2.evasion;
        this.damageReduction = statCharacterDMF2.damageReduction;
    }
}

[Serializable]
public class StatCharacterOther
{
    public float MSPD;
    public float vamp;

    public void Clone(StatCharacterOther statCharacterOther2)
    {
        this.MSPD = statCharacterOther2.MSPD;
        this.vamp = statCharacterOther2.vamp;
    }
}

[Serializable]
public class StatusATK
{
    public EStatusATKType eStatusATKType;
    public List<PropertyAffect> lstPropertyAffect = new List<PropertyAffect>();
}

[Serializable]
public class PropertyAffect
{
    public string propertyName;
    public float damage;
    public float time;
}



//public class MyClass
//{
//    public string MyProperty { get; set; }
//}

//public class Program
//{
//    public static void Main()
//    {
//        MyClass myObject = new MyClass();
//        myObject.MyProperty = "Giá trị của thuộc tính";

//        // Tên của thuộc tính bạn muốn gọi
//        string propertyName = "MyProperty";

//        // Sử dụng reflection để gọi thuộc tính bằng chuỗi
//        Type type = myObject.GetType();
//        PropertyInfo propertyInfo = type.GetProperty(propertyName);
//        if (propertyInfo != null)
//        {
//            object propertyValue = propertyInfo.GetValue(myObject);
//            Console.WriteLine($"Giá trị của thuộc tính {propertyName} là: {propertyValue}");
//        }
//        else
//        {
//            Console.WriteLine($"Không tìm thấy thuộc tính có tên {propertyName}");
//        }
//    }
//}