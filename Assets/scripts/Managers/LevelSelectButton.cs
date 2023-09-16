using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private Image image;
    [SerializeField] private GameObject lockedSprite;
    [SerializeField] private TextMeshProUGUI textMesh;
    public void SetLevelNumber(int levelNumber)
    {
        if (levelNumber == -1)
        {
            lockedSprite.SetActive(true);
            textMesh.gameObject.SetActive(false);
        }
        else
        {
            lockedSprite.SetActive(false);
            textMesh.gameObject.SetActive(true);

            textMesh.text = "Level " + (levelNumber + 1).ToString();
            btn.onClick.AddListener(() =>
            {
                LevelManager.OpenLevelFromIndex(levelNumber);
            });
        }
    }
}
