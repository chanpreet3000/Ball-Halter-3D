using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class dizziness : MonoBehaviour
{  
    private bool used = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {            
            if (other.CompareTag("Player"))
            {
                used = true;
                FindObjectOfType<audiomanager>().playaudio("whoosh");
                StartCoroutine(apply());
                StartCoroutine(anim(other.transform));
            }
        }
    }

    IEnumerator apply()
    {
        for (float i = 0; i < 1f; i += 0.004f)
        {
            GetComponent<Volume>().weight = Mathf.Lerp(0f, 1f, i);
            yield return null;
        }
    }
    IEnumerator anim(Transform player)
    {
        for (float i = 0; i < 1f; i += 1*Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, player.position,i);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero,i);            
            yield return null;
        }
    }
}
