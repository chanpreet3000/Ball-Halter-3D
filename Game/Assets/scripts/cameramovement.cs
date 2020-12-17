using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    private Transform Player;

    private bool isrotating = false;
    private float localtime = 0f;
    private int angleindex=0;
    private int[] anglearray = { 0, 90, 180, -90 };
    private Quaternion initialangle, finalangle;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Player)
        {
            transform.position = Player.position;
        }
        
        if(isrotating)
        {     
            transform.rotation =Quaternion.Lerp(initialangle, finalangle, localtime);
            localtime += Time.deltaTime;
            if(localtime>=1f)
            {
                isrotating = false;
                localtime = 0f;
            }
        }
        if(Player.GetComponent<Playermovement>().isdead)
        {
            transform.position = Vector3.Lerp(transform.position, Player.GetComponent<Playermovement>().checkpoint, localtime);
            localtime += Time.deltaTime*1/1.42f;
            if (localtime >= 1f)
            {
                Player.GetComponent<Playermovement>().isdead = false;
                localtime = 0f;
            }
        }
    }
    public void rotatecamera(int i)
    {
        if (!isrotating)
        {
            isrotating = true;
            initialangle = Quaternion.Euler(0, anglearray[angleindex], 0);
            angleindex += i;
            if (angleindex == -1)
            {
                angleindex = 3;
            }
            else if (angleindex == 4)
            {
                angleindex = 0;
            }
            finalangle = Quaternion.Euler(0, anglearray[angleindex], 0);
        }
    }
}
