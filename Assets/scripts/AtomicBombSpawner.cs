using UnityEngine;

public class AtomicBombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject atomBombPrefab;
    [SerializeField] private float timeInterval = 4f;
    [SerializeField] private float explosionForce = 4f;
    [SerializeField] private float explosionRadius = 4f;

    private void Start()
    {
        Deploy();
    }

    private void Deploy()
    {
        GameObject obj = Instantiate(atomBombPrefab, transform.position, Quaternion.identity);
        AtomBomb atomBomb = obj.GetComponent<AtomBomb>();
        atomBomb.SetExplosionForce(explosionForce);
        atomBomb.SetExplosionRadius(explosionRadius);

        Invoke("Deploy", timeInterval);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
