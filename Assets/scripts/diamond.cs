using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private GameObject diamondMesh;
    [SerializeField] private int amount = 10;
    private float localtime = 0f;
    private void Awake()
    {
        if (DiamondManager.IsDiamondUsed(this))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        transform.position = Vector3.Lerp(transform.position, other.transform.position, localtime);
        diamondMesh.transform.localScale = Vector3.Lerp(diamondMesh.transform.localScale, Vector3.zero, localtime);
        localtime += Time.deltaTime;
        if (localtime > 0.9f)
        {
            UseDiamond();
            Destroy(gameObject);
        }
    }
    private void UseDiamond()
    {
        AudioManager.Instance.PlayAudio(Sound.DiamondPick);
        DiamondManager.UseDiamond(this);
        DiamondManager.AddDiamonds(amount);
    }
}
