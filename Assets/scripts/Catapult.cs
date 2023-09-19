using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float force;
    [SerializeField] private Vector3 angle;
    public void Activate()
    {
        GameObject player = FindAnyObjectByType<PlayerMovement>().gameObject;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.AddForce(angle * force, ForceMode.Impulse);
        animator.SetTrigger("activate");
    }
}
