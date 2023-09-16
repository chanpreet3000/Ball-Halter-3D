using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private GameObject confetti;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            confetti.SetActive(true);
            GameManager.Instance.PlayerWin();
        }
    }
}
