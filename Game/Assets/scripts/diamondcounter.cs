using UnityEngine;
using UnityEngine.UI;

public class diamondcounter : MonoBehaviour
{
    public Text diamondtext;
    private void FixedUpdate()
    {
        diamondtext.text = PlayerPrefs.GetInt("diamonds", 0).ToString();
    }
}
