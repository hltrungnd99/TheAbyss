using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private DataProvider dataProvider;
    [SerializeField] private SpawnerArea spawnerArea;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        dataProvider.LoadLevelData(LoadArea);
    }

    private void LoadArea(LevelData levelData)
    {
        spawnerArea.LoadAreas(levelData);
    }
}