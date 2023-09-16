using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 axis = new Vector3(0, 1, 0);
    private void FixedUpdate()
    {
        transform.Rotate(speed * Time.fixedDeltaTime * axis);
    }
}
