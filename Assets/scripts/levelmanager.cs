using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    public int levelsoffset =0;
    public Button[] levelbtn;


    private void Awake()
    {
        for(int i=0;i<levelbtn.Length;i++)
        {
            if (PlayerPrefs.GetInt("MaxLevel", 1) > i + levelsoffset)
            {
                levelbtn[i].interactable = true;
            }
            else
            {
                levelbtn[i].interactable = false;
            }
            levelbtn[i].GetComponentInChildren<Text>().text = "Level "+ (i + levelsoffset + 1) ;
        }
    }
    public void openlevel(int levelno)
    {
        SceneManager.LoadScene("level" + levelno);
    }
}
