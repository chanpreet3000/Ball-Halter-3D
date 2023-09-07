using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicBombSpawner : MonoBehaviour
{
    public GameObject atombomb;
    private void Start()
    {
        Invoke("Deploy", 4f);
    }

    public void Deploy()
    {
        Instantiate(atombomb, transform);
        Invoke("Deploy", 4f);
    }
}
