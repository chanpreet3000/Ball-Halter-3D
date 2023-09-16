using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float smoothSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothSpeed * Time.fixedDeltaTime);
        transform.Rotate(joystick.Horizontal * rotateSpeed * Time.fixedDeltaTime * Vector3.up);
        // if (GameManager.Instance.IsPlayerDead())
        // {
        //     transform.position = Vector3.Lerp(transform.position, GameManager.Instance.GetCheckpoint(), localtime);
        //     localtime += Time.deltaTime * 1 / 1.42f;
        //     if (localtime >= 1f)
        //     {
        //         GameManager.Instance.SetPlayerDead(false);
        //         localtime = 0f;
        //     }
        // }
    }
}
