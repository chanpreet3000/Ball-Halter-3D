using UnityEngine;

public class RollingHammer : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float maxAngle = 45;
    [SerializeField] private Vector3 rotationAxis = new Vector3(1, 0, 0);
    [SerializeField] Transform rotationPoint;

    private float localTime = 0f;
    void FixedUpdate()
    {
        localTime += speed * Time.fixedDeltaTime;
        float val = Mathf.Sin(localTime) * maxAngle;
        rotationPoint.eulerAngles = rotationAxis * val;
    }
}
