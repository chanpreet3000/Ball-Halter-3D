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
        GameObject p =Instantiate(atombomb, transform);
        p.SetActive(true);
        Invoke("Deploy", 4f);
    }
}
