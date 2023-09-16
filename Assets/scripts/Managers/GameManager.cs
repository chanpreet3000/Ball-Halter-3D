using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Vector3 playerStartPosition = Vector3.zero;

    public static GameManager Instance;
    private Vector3 lastCheckPoint;
    private bool levelCompleted = false;
    private PlayerUIManager playerUIManager;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
        Instance = this;
        lastCheckPoint = playerStartPosition;
    }

    private void Start()
    {
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
        GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
        player.transform.position = GetCheckpoint();
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void PlayerWin()
    {
        if (levelCompleted) return;
        Debug.Log("Player has completed " + LevelManager.GetCurrentLevelName());
        levelCompleted = true;
        
        AudioManager.Instance.PlayAudio(Sound.PlayerWin);
        LevelManager.LevelCompleted();
        playerUIManager.levelWinScreen.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerStartPosition, 0.5f);
    }
}
