using UnityEngine;

public class BallCannon : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private GameObject rotationPoint;
    [SerializeField] private Transform shootPoint;
    private Vector3 playerExitPoint;
    [SerializeField] private float force;
    [SerializeField] private float rotSpeed;

    private float currentXRot = 0, currentYRot = 0;

    public void Start()
    {
        cameraObject.SetActive(false);
    }
    public void Enter()
    {
        PlayerUIManager.Instance.playerMovementUI.SetActive(false);
        cameraObject.SetActive(true);
    }

    public void Shoot()
    {
        PlayerUIManager.Instance.playerMovementUI.SetActive(true);
        GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
        player.transform.position = shootPoint.position;
        player.GetComponent<Rigidbody>().AddForce(shootPoint.forward * force, ForceMode.Impulse);
        cameraObject.SetActive(false);
    }

    public void Exit()
    {
        PlayerUIManager.Instance.playerMovementUI.SetActive(true);
        cameraObject.SetActive(false);
    }

    public void Move(Vector2 Input)
    {
        currentXRot += Input.x * rotSpeed * Time.fixedDeltaTime;
        currentYRot += Input.y * rotSpeed * Time.fixedDeltaTime;
        rotationPoint.transform.eulerAngles = new Vector3(-currentYRot, currentXRot, 0);
    }
}
