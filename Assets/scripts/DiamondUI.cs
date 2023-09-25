using UnityEngine;
using TMPro;
public class DiamondUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI diamondText;
    void FixedUpdate()
    {
        diamondText.SetText(DiamondManager.GetTotalDiamonds().ToString());
    }
}
