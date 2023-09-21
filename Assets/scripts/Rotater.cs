using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.fixedDeltaTime));
    }
}
