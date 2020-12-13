using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    public GameObject firepoint, bullet;
    // Start is called before the first frame update
    void Start()
    {
        shoot();   
    }

    public void shoot()
    {
        GameObject b1 = Instantiate(bullet, firepoint.transform.position, Quaternion.identity);
        b1.GetComponent<Rigidbody>().AddForce(transform.forward * - 900*7);
        b1.GetComponent<Rigidbody>().AddTorque(new Vector3(0,0, 000));
        b1.transform.localScale = Vector3.one * 0.5f;
        Invoke("shoot",2f);
        Destroy(b1, 1.5f);
    }
}
