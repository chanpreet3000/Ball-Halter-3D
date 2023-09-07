using UnityEngine;

public class atombomb : MonoBehaviour
{
    public GameObject particles;
    public float explosionforce=8f;

    private bool used = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (!used)
        {
            used = true;
            GameObject p = Instantiate(particles, transform);
            p.transform.parent = transform.parent;
            Destroy(p, 3f);
            Destroy(gameObject);

            Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);

            foreach (Collider s in colliders)
            {
                Rigidbody rb = s.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionforce, transform.position, 4f, explosionforce, ForceMode.Impulse);
                }
            }
        }
    }
    
}
