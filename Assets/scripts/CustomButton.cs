using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private Sound sound = Sound.ButtonClick1;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlayAudio(sound);
        });
    }
}
