using UnityEngine;

public class PowerJump : MonoBehaviour
{
    [SerializeField] private float force = 14f;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<Rigidbody>().AddForce(force * transform.up, ForceMode.Impulse);
        AudioManager.Instance.PlayAudio(Sound.PowerJump);
    }
}
