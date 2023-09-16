using UnityEngine;
public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform checkpointPosition;
    private bool checkpointReached = false;
    private void OnTriggerEnter(Collider other)
    {
        if (checkpointReached || !other.CompareTag("Player")) return;
        checkpointReached = true;

        GameManager.Instance.SetCheckpoint(checkpointPosition.position);
        GetComponentInChildren<Animator>().SetTrigger("reached");
        AudioManager.Instance.PlayAudio(Sound.Checkpoint);
    }
}
