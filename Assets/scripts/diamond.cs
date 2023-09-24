using System.Collections;
using UnityEngine;
public class Diamond : MonoBehaviour
{
    [SerializeField] private GameObject diamondMesh;
    [SerializeField] private int amount = 10;
    bool used = false;
    private void Awake()
    {
        if (DiamondManager.IsDiamondUsed(this))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;
        used = true;
        UseDiamond();
        StartCoroutine(AnimateDizziness(other.transform));
    }
    IEnumerator AnimateDizziness(Transform player)
    {
        for (float i = 0; i <= 1f; i += 1f * Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, player.position, i);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, i);
            yield return null;
        }
    }
    private void UseDiamond()
    {
        AudioManager.Instance.PlayAudio(Sound.DiamondPick);
        DiamondManager.UseDiamond(this);
        DiamondManager.AddDiamonds(amount);
    }
}
