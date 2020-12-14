using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerjump : MonoBehaviour
{
    public float force = 14f;
    public Vector3 v = new Vector3(0,1,0);
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(force * v,ForceMode.Impulse);
            FindObjectOfType<audiomanager>().playaudio("spring");
        }
    }
}
