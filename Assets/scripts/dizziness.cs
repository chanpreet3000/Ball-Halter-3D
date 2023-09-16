using System.Collections;
using UnityEngine;

public class Dizziness : MonoBehaviour
{
    private bool used = false;
    private void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (other.CompareTag("Player"))
        {
            used = true;
            AudioManager.Instance.PlayAudio(Sound.DizzinessWosh);
            StartCoroutine(ApplyEffect());
            StartCoroutine(AnimateDizziness(other.transform));
        }
    }

    IEnumerator ApplyEffect()
    {
        for (float i = 0; i < 1f; i += 0.004f)
        {
            // GetComponent<PostProcessVolume>().weight = Mathf.Lerp(0f, 1f, i);
            yield return null;
        }
    }
    IEnumerator AnimateDizziness(Transform player)
    {
        for (float i = 0; i < 1f; i += 1 * Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, player.position, i);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, i);
            yield return null;
        }
    }
}
