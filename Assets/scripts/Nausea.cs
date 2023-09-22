using System.Collections;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class Nausea : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessingVolume;
    [SerializeField] private float nauseaXEffectSpeed = 0.5f;
    [SerializeField] private float nauseaYEffectSpeed = 0.5f;
    [SerializeField] private float nauseaXEffectFactor = 10f;
    [SerializeField] private float nauseaYEffectFactor = 10f;
    private bool used = false;
    private void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;
        used = true;
        AudioManager.Instance.PlayAudio(Sound.DizzinessWosh);
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
        StartCoroutine(ApplyEffect());
    }
    IEnumerator ApplyEffect()
    {
        for (float i = 0; i <= 1f; i += 1f * Time.deltaTime)
        {
            postProcessingVolume.weight = Mathf.Lerp(0f, 1f, i);
            yield return null;
        }

        float localXTime = 0, localYTime = 0;
        while (true)
        {
            localXTime += nauseaXEffectSpeed * Time.deltaTime;
            localYTime += nauseaYEffectSpeed * Time.deltaTime;

            float valX = Mathf.Sin(localXTime) / nauseaXEffectFactor;
            float valY = Mathf.Sin(localYTime) / nauseaYEffectFactor;

            ((LensDistortion)postProcessingVolume.profile.settings[0]).centerX.value = valX;
            ((LensDistortion)postProcessingVolume.profile.settings[0]).centerY.value = valY;
            yield return null;
        }
    }
}
