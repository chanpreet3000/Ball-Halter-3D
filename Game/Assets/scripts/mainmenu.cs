using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void howtoplaybtn()
    {
        SceneManager.LoadScene("level0");
    }
    public void playbtn()
    {
        SceneManager.LoadScene("level" + PlayerPrefs.GetInt("MaxLevel", 1));
    }
}
