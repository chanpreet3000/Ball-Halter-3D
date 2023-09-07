using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour
{
    public string gameId = "3926725";
    public string placementId = "banner";
    public bool testMode = true,showad=true;

    void Start()
    {
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Initialize(gameId, testMode);
        if (showad)
        {
            StartCoroutine(ShowBannerWhenInitialized());
        }
        else
        {
            Advertisement.Banner.Hide();
        }
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }
}