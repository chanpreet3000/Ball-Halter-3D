using UnityEngine;

[System.Serializable]
public class sounds
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]    public float volume = 1f;
    [Range(0.1f,3f)]   public float pitch = 1f;   
    public bool loop = false , playonstart = false;


    [HideInInspector] public AudioSource source;
}
