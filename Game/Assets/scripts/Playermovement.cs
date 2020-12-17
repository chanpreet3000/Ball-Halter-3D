using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Material[] skins;
    public Transform Camerabase;
    public Joystick joystick;
    public float torquemultiplier = 25f,maxvelocity=600f;
    private Rigidbody Rb;
    [HideInInspector] public bool isdead = false;
    public Vector3 checkpoint = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = skins[PlayerPrefs.GetInt("skinnumber",0)];
        Rb = GetComponent<Rigidbody>();
        checkpoint = transform.position;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") + joystick.Horizontal;
        float vertical = Input.GetAxis("Vertical")+ joystick.Vertical;
        Move(horizontal,vertical);
        clampingvelocity();
    }
    public void Move(float horizontal, float vertical)
    {
        Rb.AddTorque((Camera.main.transform.parent.right*vertical - Camera.main.transform.parent.forward * horizontal) * torquemultiplier * Time.deltaTime, ForceMode.VelocityChange);
    }
    public void clampingvelocity()
    {
        Rb.velocity = new Vector3(Mathf.Clamp(Rb.velocity.x, -maxvelocity, maxvelocity), Rb.velocity.y, Mathf.Clamp(Rb.velocity.z, -maxvelocity, maxvelocity));
    }   
}
