using UnityEngine;

public class SpikeTrapDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        animator.SetTrigger("activate");
    }
    public void PlayAudio(){
        audioSource.Play();
    }
}
