using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private Vector3 rotateAxis = new Vector3(0, 0, 1);
    private void FixedUpdate()
    {
        transform.Rotate(rotateAxis * rotateSpeed * Time.fixedDeltaTime);
    }
}
