using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Material[] skins;
    [SerializeField] private Transform cameraBase;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float torque = 25f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer mr;
    private Transform parent;
    private void Start()
    {
        parent = transform.parent;
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") + joystick.Horizontal;
        float vertical = Input.GetAxis("Vertical") + joystick.Vertical;
        rb.AddTorque(torque * Time.fixedDeltaTime * (cameraBase.right * vertical - cameraBase.forward * horizontal), ForceMode.VelocityChange);

        AttackToPlayerHolder();
    }
    private void AttackToPlayerHolder()
    {
        Transform holder = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position - new Vector3(0, transform.localScale.y / 2, 0), 0.05f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("PlayerHolder"))
            {
                holder = collider.transform;
                break;
            }
        }
        if (holder == null)
            transform.parent = parent;
        else
            transform.parent = holder;
    }
}
