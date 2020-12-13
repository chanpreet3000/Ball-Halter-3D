using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject winningscreen,deathparticle;
    public Text winningscreenleveltext, leveltext;

    private GameObject Player;        
    private bool isdead=false;
    public int currentlevelno=0;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        leveltext.text = PlayerPrefs.GetInt("MaxLevel", 1).ToString("0");
        leveltext.text = currentlevelno.ToString();
    }
    public void Die()
    {
        if (!isdead)
        {
            isdead = true;
            Instantiate(deathparticle, Player.transform.position + Vector3.up,Quaternion.identity);
            Invoke("restartfromcheckpoint", 1.4f);
        }
        
    }
    public void pausegame()
    {
        Time.timeScale = 0;
    }
    public void resumegame()
    {
        Time.timeScale = 1;
    }
    public void restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void restartfromcheckpoint()
    {
        isdead = false;
        Analytics.CustomEvent("LevelDied", new Dictionary<string, object>
        {
            { "Level", currentlevelno}
        });
        Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        Player.transform.position = Player.GetComponent<Playermovement>().checkpoint;
    }
    public void openlevel(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void win(int levelno)
    {
        currentlevelno = levelno;
        winningscreen.SetActive(true);
        winningscreenleveltext.text = "Level " + levelno + " Completed!!";
        if (currentlevelno >= PlayerPrefs.GetInt("MaxLevel", 1))
        {
            PlayerPrefs.SetInt("MaxLevel", currentlevelno + 1);
        }
        Analytics.CustomEvent("LevelWin", new Dictionary<string, object>
        {
            { "Level", currentlevelno},
            { "timetakentoomplete", Time.timeSinceLevelLoad }
        });
    }

    public void winningscreennextlevelbtn()
    {       
        SceneManager.LoadScene("level" + (currentlevelno + 1));
    }
}
