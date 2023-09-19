using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float magnetForce = 10f;
    [SerializeField] private Transform magnetOrigin;
    [SerializeField] private LineRenderer lineRenderer;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rb) && rb.gameObject.CompareTag("Player"))
        {
            lineRenderer.enabled = true;
            rb.AddForce(magnetForce * Time.deltaTime * (magnetOrigin.position - rb.transform.position));
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, magnetOrigin.position);
            lineRenderer.SetPosition(1, rb.transform.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        lineRenderer.enabled = false;
    }
}
