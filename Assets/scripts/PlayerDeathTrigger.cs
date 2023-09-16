using UnityEngine;

public class PlayerDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameManager.Instance.PlayerDead();
    }
}
