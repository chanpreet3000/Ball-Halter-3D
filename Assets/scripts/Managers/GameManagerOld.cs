using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameManagerOld : MonoBehaviour
{
    // public GameObject AM;
    // public GameObject winningscreen,deathparticle;
    // public Text winningscreenleveltext, leveltext;

    // private GameObject Player;
    // [HideInInspector]public int currentlevelno=0;

    // private void Start()
    // {
    //     Debug.Log("Current levels is" + LevelManager.GetCurrentLevelName());
    //     Player = GameObject.FindGameObjectWithTag("Player");
    //     leveltext.text = PlayerPrefs.GetInt("MaxLevel", 1).ToString("0");
    //     leveltext.text = currentlevelno.ToString();
    //     // if(FindObjectOfType<audiomanager>()==null)
    //     // {
    //     //     GameObject g=Instantiate(AM, transform.position , Quaternion.identity);
    //     // }
    // }
    // public void Die()
    // {
    //     // if (!Player.GetComponent<Playermovement>().isdead)
    //     // {
    //     //     FindObjectOfType<audiomanager>().playaudio("death");
    //     //     Player.GetComponent<Playermovement>().isdead = true;
    //     //     Instantiate(deathparticle, Player.transform.position + Vector3.up,Quaternion.identity);
    //     //     Invoke("restartfromcheckpoint", 1.4f);
    //     // }
        
    // }
    // public void pausegame()
    // {
    //     Time.timeScale = 0;
    // }
    // public void resumegame()
    // {
    //     Time.timeScale = 1;
    // }
    // public void restartlevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
    // public void restartfromcheckpoint()
    // {
    //     Analytics.CustomEvent("LevelDied", new Dictionary<string, object>
    //     {
    //         { "Level", currentlevelno}
    //     });
    //     Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //     Player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //     Player.transform.rotation = Quaternion.Euler(0, 0, 0);
    //     // Player.transform.position = Player.GetComponent<Playermovement>().checkpoint;        
    // }
    // public void openlevel(int i)
    // {
    //     SceneManager.LoadScene(i);
    // }
    // public void win(int levelno)
    // {
    //     currentlevelno = levelno;
    //     winningscreenleveltext.text = "Level " + levelno + " Completed!!";
    //     if (currentlevelno >= PlayerPrefs.GetInt("MaxLevel", 1))
    //     {
    //         PlayerPrefs.SetInt("MaxLevel", currentlevelno + 1);
    //     }
    //     Invoke("activatewinningscreen", 2.5f);
    //     Analytics.CustomEvent("LevelWin", new Dictionary<string, object>
    //     {
    //         { "Level", currentlevelno}
    //     });
    // }
    // public void activatewinningscreen()
    // {
    //     winningscreen.SetActive(true);
    // }

    // public void winningscreennextlevelbtn()
    // {       
    //     SceneManager.LoadScene("level" + (currentlevelno + 1));
    // }
}
