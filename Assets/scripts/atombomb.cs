using UnityEngine;

public class AtomBomb : MonoBehaviour
{
    [SerializeField] private GameObject explosionParticle;
    private float explosionForce;
    private float explosionRadius = 4f;
    private bool used = false;
    public void SetExplosionForce(float explosionForce)
    {
        this.explosionForce = explosionForce;
    }
    public void SetExplosionRadius(float explosionRadius)
    {
        this.explosionRadius = explosionRadius;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (used) return;
        used = true;
        GameObject particleObject = Instantiate(explosionParticle, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider obj in colliders)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(particleObject, 3f);
        Destroy(gameObject);
    }

}
