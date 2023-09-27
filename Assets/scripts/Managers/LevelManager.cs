using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    public static readonly string trainingSceneName = "Training";
    public static readonly string mainMenuSceneName = "Main Menu";
    public static readonly string[] levels = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
     "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
    private static readonly string UNLOCKED_LEVEL_INDEX = "UNLOCKED_LEVEL_INDEX";

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

        int currentLevelIndex = GetCurrentLevelIndex();
        if (currentLevelIndex == -1) return "Add the level name to Level Manager";
        return "Level " + (currentLevelIndex + 1).ToString();
    }

    public static int GetCurrentLevelIndex()
    {
        string levelName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < levels.Length; i++)
            if (levels[i] == levelName) return i;
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
        // If Training open main menu
        if (GetCurrentLevelName() == trainingSceneName)
        {
            OpenMainMenu();
            return;
        }

        // If Last level open main menu
        int index = GetCurrentLevelIndex();
        if (index == levels.Length - 1)
        {
            OpenMainMenu();
            return;
        }

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
