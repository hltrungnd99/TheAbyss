using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    public int currentLevel
    {
        get => PlayerPrefs.GetInt("currentLevel", 0);
        set => PlayerPrefs.SetInt("currentLevel", value);
    }
}