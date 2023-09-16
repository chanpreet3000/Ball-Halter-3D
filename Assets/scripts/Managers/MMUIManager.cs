using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject levelSelectUI;
    [SerializeField] private TextMeshProUGUI diamondText;
    void Start()
    {
        diamondText.SetText(DiamondManager.GetTotalDiamonds().ToString());
    }
    public void OpenTraining()
    {
        SceneManager.LoadScene(LevelManager.trainingSceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayBtnClicked(){
        mainMenuUI.SetActive(false);
        levelSelectUI.SetActive(true);
    }

    public void LevelSelectBackBtnClicked(){
        mainMenuUI.SetActive(true);
        levelSelectUI.SetActive(false);
    }
}
