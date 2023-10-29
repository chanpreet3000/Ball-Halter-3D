using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float followSmoothness;
    [SerializeField] private float rotateSmoothness;

    private float yAngle = 0f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, followSmoothness);
        yAngle += joystick.Horizontal * rotateSpeed * Time.deltaTime;
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, yAngle, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * rotateSmoothness);
    }
}
