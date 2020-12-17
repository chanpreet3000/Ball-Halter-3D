using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Image mutebtn;
    public Sprite mute, unmute;
    public Text graphicstext;
    private string[] graphictextarray = { "LOW", "MEDIUM", "HIGH" };
    private bool ismuted = false;

    private void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityindex", 2));
        graphicstext.text = graphictextarray[PlayerPrefs.GetInt("qualityindex", 2)];
    }
    public void changegraphicsquality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
        PlayerPrefs.SetInt("qualityindex", qualityindex);
        graphicstext.text = graphictextarray[qualityindex];
    }
    public void resettodefaultsettings()
    {
        PlayerPrefs.SetInt("qualityindex", 2);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityindex", 2));
        graphicstext.text = graphictextarray[PlayerPrefs.GetInt("qualityindex", 2)];
    }

    public void mutebtnclicked()
    {        
        ismuted = !ismuted;
        AudioListener.pause = ismuted;
        if(ismuted)
        {
            mutebtn.sprite = mute;
        }
        else
        {
            mutebtn.sprite = unmute;
        }
    }

    public void settingsmutetogglebtn(bool ison)
    {
        AudioListener.pause = ison;
    }
}
