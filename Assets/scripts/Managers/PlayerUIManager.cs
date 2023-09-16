using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject playerHUD;
    public GameObject pauseMenu;
    public GameObject loadingScreen;
    public GameObject levelIntroScreen;
    public GameObject levelWinScreen;
    public TextMeshProUGUI levelIntroText;

    public static PlayerUIManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        levelIntroText.SetText(LevelManager.GetCurrentLevelName());
    }

    public void PauseBtnClicked()
    {
        pauseMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        LevelManager.RestartLevel();
    }
    public void OpenMainMenu()
    {
        LevelManager.OpenMainMenu();
    }

    public void OpenNextLevel()
    {
        LevelManager.OpenNextLevel();
    }
}
