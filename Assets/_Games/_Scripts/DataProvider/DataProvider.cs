using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DataProvider : Singleton<DataProvider>
{
    [FormerlySerializedAs("DataArea")] public LevelData dataLevel;
}
