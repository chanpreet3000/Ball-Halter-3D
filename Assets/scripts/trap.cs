using UnityEngine;

public class Trap : MonoBehaviour
{
    public void Playaudio()
    {
        AudioManager.Instance.PlayAudio(Sound.Trap);
    }
}
