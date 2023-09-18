using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
    }
}