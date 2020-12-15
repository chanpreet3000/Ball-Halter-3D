using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atombomb : MonoBehaviour
{
    public GameObject particles;
    private void OnCollisionEnter(Collision collision)
    {

        particles.SetActive(true);
        Destroy(gameObject, 3f);
    }
}
