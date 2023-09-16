using UnityEngine;
public class Elevator : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private Vector3 endPosition;
    private Vector3 startPosition;
    private float time = 0f;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        time += speed * Time.fixedDeltaTime;
        float val = (Mathf.Sin(time) + 1) / 2f;
        transform.position = Vector3.Lerp(startPosition, endPosition, val);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(endPosition, 0.5f);
    }
}
