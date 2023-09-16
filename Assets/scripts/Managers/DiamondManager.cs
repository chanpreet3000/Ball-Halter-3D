using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondManager
{
    private static string DIAMOND_VALUE_KEY = "DIAMOND_VALUE_KEY";
    private static int initialDiamondValue = 100;

    public static int GetTotalDiamonds()
    {
        return PlayerPrefs.GetInt(DIAMOND_VALUE_KEY, initialDiamondValue);
    }

    private static void SetTotalDiamonds(int value)
    {
        PlayerPrefs.SetInt(DIAMOND_VALUE_KEY, value);
    }

    public static void AddDiamonds(int value)
    {
        SetTotalDiamonds(GetTotalDiamonds() + value);
    }

    private static string GetDiamondId(Diamond diamond)
    {
        return "DIAMOND_" + SceneManager.GetActiveScene().name + diamond.gameObject.name;
    }
    public static bool IsDiamondUsed(Diamond diamond)
    {
        return PlayerPrefs.HasKey(GetDiamondId(diamond));
    }
    public static void UseDiamond(Diamond diamond)
    {
        PlayerPrefs.SetInt(GetDiamondId(diamond), 1);
    }
}
