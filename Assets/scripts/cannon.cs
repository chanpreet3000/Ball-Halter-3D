using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float timeBetweenBullets = 2f;
    [SerializeField] private float timeToDestroyBullet = 1.5f;
    [SerializeField] private float bulletForce = 2f;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        audioSource.Play();
        GameObject bulletObject = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletForce * bulletSpawnPoint.right);
        Invoke("Shoot", timeBetweenBullets);
        Destroy(bulletObject, timeToDestroyBullet);
    }
}
