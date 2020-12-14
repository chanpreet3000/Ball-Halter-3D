using UnityEngine;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour
{
    public sounds[] sounds;


    private static audiomanager Instance;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach(sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if(s.playonstart)
            {
                s.source.Play();
            }
        }
    }

    public void playaudio(string audioname)
    {
        foreach (sounds s in sounds)
        {
           if(s.name==audioname)
            {
                s.source.Play();
            }
        }
    }
}
