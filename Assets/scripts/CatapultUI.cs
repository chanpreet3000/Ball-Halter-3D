using UnityEngine;

public class CatapultUI : MonoBehaviour
{
    [SerializeField] private GameObject catapultUI;
    private Transform player;

    private float radius = 1f;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject.transform;
    }

    void FixedUpdate()
    {
        bool f = false;
        Collider[] colliders = Physics.OverlapSphere(player.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Catapult catapult))
            {
                f = true;
                break;
            }
        }
        catapultUI.SetActive(f);
    }

    public void CatapultActivateBtnClicked()
    {
        Collider[] colliders = Physics.OverlapSphere(player.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Catapult catapult))
            {
                catapult.Activate();
                break;
            }
        }
    }
}
