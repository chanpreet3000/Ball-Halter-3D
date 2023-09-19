using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Vector3 playerStartPosition = Vector3.zero;

    public static GameManager Instance;
    private Vector3 lastCheckPoint;
    private bool levelCompleted = false;
    public PlayerUIManager playerUIManager;

    private float startTime;
    private float completedAtTime;
    private int totalDeaths;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
        Instance = this;
        lastCheckPoint = playerStartPosition;
        startTime = Time.time;
        totalDeaths = 0;
    }

    private void Start()
    {
        Time.timeScale = 1;
        GameObject player = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        playerUIManager = player.GetComponentInChildren<PlayerUIManager>();
        PlayerUIManager.Instance.loadingScreen.SetActive(true);
        PlayerUIManager.Instance.playerHUD.SetActive(true);
        PlayerUIManager.Instance.levelIntroScreen.SetActive(true);
    }

    public void SetCheckpoint(Vector3 point)
    {
        lastCheckPoint = point;
    }
    public Vector3 GetCheckpoint()
    {
        return lastCheckPoint;
    }
    public void PlayerDead()
    {
        totalDeaths++;
        FindObjectOfType<CameraMovement>().enabled = false;

        GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
        player.transform.position = GetCheckpoint();
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        FindObjectOfType<CameraMovement>().enabled = true;
    }
    public void PlayerWin()
    {
        if (levelCompleted) return;
        Debug.Log("Player has completed " + LevelManager.GetCurrentLevelName());
        levelCompleted = true;
        completedAtTime = Time.time;

        AudioManager.Instance.PlayAudio(Sound.PlayerWin);
        LevelManager.LevelCompleted();
        playerUIManager.levelWinScreen.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerStartPosition, 0.5f);
    }
    public int GetTotalDeaths()
    {
        return totalDeaths;
    }
    public float GetPlayerLevelTime()
    {
        if (levelCompleted)
            return completedAtTime - startTime;
        return Time.time - startTime;
    }
}
