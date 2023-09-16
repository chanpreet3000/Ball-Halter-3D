using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 endPosition = Vector3.zero;
    private float time = 0f;
    private Vector3 startPosition;
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
