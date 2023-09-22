using UnityEngine;

public class BallCannonUI : MonoBehaviour
{
    [SerializeField] private GameObject beforeUI;
    [SerializeField] private GameObject afterUI;
    [SerializeField] private Joystick joystick;
    private Transform player;

    private float radius = 4f;
    private BallCannon prevBallCannon = null;
    void Start()
    {
        beforeUI.SetActive(false);
        afterUI.SetActive(false);
        player = FindAnyObjectByType<PlayerMovement>().gameObject.transform;
    }

    void FixedUpdate()
    {
        if (prevBallCannon != null)
        {
            prevBallCannon.Move(new Vector2(joystick.Horizontal, joystick.Vertical));
            return;
        };
        bool f = false;
        Collider[] colliders = Physics.OverlapSphere(player.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out BallCannon ballCannon))
            {
                f = true;
                break;
            }
        }
        beforeUI.SetActive(f);
    }

    public void ActivateBtnClicked()
    {
        Collider[] colliders = Physics.OverlapSphere(player.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out BallCannon ballCannon))
            {
                prevBallCannon = ballCannon;
                beforeUI.SetActive(false);
                afterUI.SetActive(true);
                ballCannon.Enter();
                break;
            }
        }
    }

    public void ShootBtnClicked()
    {
        beforeUI.SetActive(false);
        afterUI.SetActive(false);
        prevBallCannon.Shoot();

        prevBallCannon = null;
    }

    public void ExitBtnClicked()
    {
        beforeUI.SetActive(false);
        afterUI.SetActive(false);
        prevBallCannon.Exit();

        prevBallCannon = null;
    }
}
