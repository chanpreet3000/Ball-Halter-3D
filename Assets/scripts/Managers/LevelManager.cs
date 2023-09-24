using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    public static string trainingSceneName = "Training";
    public static string mainMenuSceneName = "Main Menu";
    public static string[] levels = { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5","Level 6","Level 7","Level 8","Level 9",
    "Level 10", "Level 11", "Level 12", "Level 13", "Level 14", "Level 15", "Level 16", "Level 17", "Level 18", "Level 19"};

    private static string UNLOCKED_LEVEL_INDEX = "UNLOCKED_LEVEL_INDEX";

    public static int GetUnlockedLevelIndex()
    {
        return PlayerPrefs.GetInt(UNLOCKED_LEVEL_INDEX, 0);
    }
    private static void SetUnlockedLevelIndex(int val)
    {
        PlayerPrefs.SetInt(UNLOCKED_LEVEL_INDEX, val);
    }

    public static string GetCurrentLevelName()
    {
        string levelName = SceneManager.GetActiveScene().name;
        if (levelName == trainingSceneName || levelName == mainMenuSceneName)
            return levelName;
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i] == levelName) return "Level " + (i + 1).ToString();
        }
        return "Add the level name to Level Manager";
    }

    public static int GetCurrentLevelIndex()
    {
        string levelName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i] == levelName) return i;
        }
        return -1;
    }

    public static void OpenLevelFromIndex(int levelIndex)
    {
        SceneManager.LoadScene(levels[levelIndex]);
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void OpenMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public static void OpenNextLevel()
    {
        if (GetCurrentLevelName() == trainingSceneName)
        {
            OpenMainMenu();
            return;
        }

        int index = GetCurrentLevelIndex();
        if (index == levels.Length - 1)
        {
            OpenMainMenu();
            return;
        }

        //
        OpenLevelFromIndex(index + 1);
    }
    public static void LevelCompleted()
    {
        if (GetCurrentLevelName() == trainingSceneName)
            return;
        int val = GetUnlockedLevelIndex();
        int index = GetCurrentLevelIndex();
        SetUnlockedLevelIndex(Mathf.Max(val, index + 1));
    }

    public static void UnlockAllLevels()
    {
        SetUnlockedLevelIndex(levels.Length - 1);
    }
}
