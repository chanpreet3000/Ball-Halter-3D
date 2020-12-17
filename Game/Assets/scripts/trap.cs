using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public void playaudio()
    {
        GetComponent<AudioSource>().Play();
    }
}
