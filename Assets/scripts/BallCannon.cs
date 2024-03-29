using UnityEngine;

public class BallCannon : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private GameObject rotationPoint;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Vector3 playerExitPoint;
    [SerializeField] private float force;
    [SerializeField] private float rotSpeed;

    private float currentXRot = 0, currentYRot = 0;

    public void Start()
    {
        cameraObject.SetActive(false);
    }
    public void Enter(Transform player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        player.gameObject.SetActive(false);
        PlayerUIManager.Instance.playerMovementUI.SetActive(false);
        cameraObject.SetActive(true);
    }

    public void Shoot(Transform player)
    {
        AudioManager.Instance.PlayAudio(Sound.BallCannon);
        player.gameObject.SetActive(true);
        PlayerUIManager.Instance.playerMovementUI.SetActive(true);
        player.GetComponent<Rigidbody>().AddForce(shootPoint.forward * force, ForceMode.Impulse);
        cameraObject.SetActive(false);
    }

    public void Exit(Transform player)
    {
        player.gameObject.SetActive(true);
        PlayerUIManager.Instance.playerMovementUI.SetActive(true);
        cameraObject.SetActive(false);
        player.position = playerExitPoint;
    }

    public void Move(Transform player, Vector2 Input)
    {
        player.position = shootPoint.position;
        currentXRot += Input.x * rotSpeed * Time.fixedDeltaTime;
        currentYRot += Input.y * rotSpeed * Time.fixedDeltaTime;
        rotationPoint.transform.eulerAngles = new Vector3(-currentYRot, currentXRot, 0);
    }

      private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerExitPoint, 0.5f);
    }
}
