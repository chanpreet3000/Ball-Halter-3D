using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbarrier : MonoBehaviour
{
    private GameManager gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gm.Die();
        }
    }
}
