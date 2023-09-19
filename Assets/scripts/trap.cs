using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public void Playaudio()
    {
        audioSource.Play();
    }
}
