using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Slider musicslider;
    public Text musicslidertext, graphicstext;
    private string[] graphictextarray = { "LOW", "MEDIUM", "HIGH" };

    private void Start()
    {
        musicslider.value = PlayerPrefs.GetFloat("musicvolume", 1f);
        musicslidertext.text = System.Math.Round(musicslider.value, 1).ToString();
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityindex", 2));
        graphicstext.text = graphictextarray[PlayerPrefs.GetInt("qualityindex", 2)];
    }
    public void onmusicslidervaluechange()
    {
        PlayerPrefs.SetFloat("musicvolume", musicslider.value);
        musicslidertext.text = System.Math.Round(musicslider.value, 1).ToString();        
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
        PlayerPrefs.SetFloat("musicvolume", 1f);
        musicslider.value = PlayerPrefs.GetFloat("musicvolume", 1f);
        musicslidertext.text = System.Math.Round(musicslider.value, 1).ToString();
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityindex", 2));
        graphicstext.text = graphictextarray[PlayerPrefs.GetInt("qualityindex", 2)];
    }
}
