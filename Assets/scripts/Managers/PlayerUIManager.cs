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
    public TextMeshProUGUI playerDeathCounterText;
    public TextMeshProUGUI playerLevelTimerText;
    public TextMeshProUGUI winScreenPlayerDeathCounterText;
    public TextMeshProUGUI winScreenPlayerLevelTimerText;

    public static PlayerUIManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        levelIntroText.SetText(LevelManager.GetCurrentLevelName());
    }

    private void FixedUpdate()
    {
        playerDeathCounterText.SetText(GameManager.Instance.GetTotalDeaths().ToString());
        playerLevelTimerText.SetText(((int)GameManager.Instance.GetPlayerLevelTime()).ToString() + "s");

        winScreenPlayerDeathCounterText.SetText(GameManager.Instance.GetTotalDeaths().ToString());
        winScreenPlayerLevelTimerText.SetText(((int)GameManager.Instance.GetPlayerLevelTime()).ToString() + " sec");
    }

    public void PauseBtnClicked()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeBtnClicked()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
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
