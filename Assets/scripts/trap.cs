using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        animator.SetBool("ActivateTrap", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        animator.SetBool("ActivateTrap", false);
    }
    public void Playaudio()
    {
        AudioManager.Instance.PlayAudio(Sound.Trap);
    }
}
