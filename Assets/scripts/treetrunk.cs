using UnityEngine;

public class TreeTrunk : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudio(Sound.TreeCrack);
            animator.SetTrigger("Trigger");
        }
    }
}
