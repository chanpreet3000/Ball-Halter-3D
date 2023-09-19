using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Material[] skins;
    [SerializeField] private Transform cameraBase;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float torque = 25f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer mr;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") + joystick.Horizontal;
        float vertical = Input.GetAxis("Vertical") + joystick.Vertical;
        rb.AddTorque(torque * Time.fixedDeltaTime * (cameraBase.right * vertical - cameraBase.forward * horizontal), ForceMode.VelocityChange);
    }
}
