using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    private Transform parent = null;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        parent = collision.collider.transform.parent;
        collision.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        collision.collider.transform.SetParent(parent);
        parent = null;
    }
}
