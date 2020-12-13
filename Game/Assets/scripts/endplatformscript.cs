using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endplatformscript : MonoBehaviour
{
    public int currentlevelno = 0;
    public GameObject confetti;
    private GameManager gm;
    public void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.currentlevelno = currentlevelno;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print("You won level complete");
            gm.win(currentlevelno);
            confetti.SetActive(true);
        }
    }
}
