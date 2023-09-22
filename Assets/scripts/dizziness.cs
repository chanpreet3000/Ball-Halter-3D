﻿using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Dizziness : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessingVolume;
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
    }
}
