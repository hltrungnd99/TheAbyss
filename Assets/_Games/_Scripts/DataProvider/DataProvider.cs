using System;
using System.Collections;
using UnityEngine;

public class DataProvider : Singleton<DataProvider>
{
    public LevelData dataLevel;

    public void LoadLevelData(Action<LevelData> callback = null)
    {
        StartCoroutine(IELoadLevelData(callback));
    }

    private IEnumerator IELoadLevelData(Action<LevelData> callback = null)
    {
        var request = Resources.LoadAsync<LevelData>(Const.pathLevel + GameData.instance.currentLevel);
        yield return request;
        dataLevel = request.asset as LevelData;
        callback?.Invoke(dataLevel);
    }
}