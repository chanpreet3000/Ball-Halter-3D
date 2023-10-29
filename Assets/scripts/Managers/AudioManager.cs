using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
        public bool loop = false;
        public float volume = 1.0f;
    }
    [SerializeField] private SoundAudioClip[] soundAudioClipArray;

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = Instantiate(Resources.Load("AudioManager")) as GameObject;
                _instance = obj.GetComponent<AudioManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }
    private bool levelMusicStarted = false;
    public void PlayAudio(Sound sound)
    {
        SoundAudioClip soundAudioClip = GetAudioClip(sound);
        if (soundAudioClip == null) return;
        //
        AudioClip audioClip = soundAudioClip.audioClip;
        GameObject soundGameObject = new GameObject(sound.ToString());
        AudioSource audiosource = soundGameObject.AddComponent<AudioSource>();
        audiosource.loop = soundAudioClip.loop;
        audiosource.volume = soundAudioClip.volume;
        audiosource.clip = audioClip;
        audiosource.Play();
        //
        DontDestroyOnLoad(soundGameObject);
        if (!audiosource.loop)
        {
            Destroy(soundGameObject, audioClip.length);
        }
    }
    public void PlayLevelAudio()
    {
        if (levelMusicStarted) return;
        levelMusicStarted = true;
        PlayAudio(Sound.LevelMusic);
    }
    public SoundAudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip item in soundAudioClipArray)
        {
            if (item.sound == sound) return item;
        }
        return null;
    }
}
