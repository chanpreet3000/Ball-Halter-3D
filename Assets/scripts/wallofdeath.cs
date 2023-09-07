using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallofdeath : MonoBehaviour
{
    public float distance=3f, time=4f;
    private float localtime = 0f;
    void FixedUpdate()
    {
        transform.localPosition = new Vector3((Mathf.Sin(localtime * 1 / time * 4))*distance, 0, 0);
        localtime += Time.deltaTime;
    }
}
