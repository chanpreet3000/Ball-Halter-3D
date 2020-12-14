using UnityEngine;
public class checkpoint : MonoBehaviour
{
    private bool hasreached = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasreached)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Playermovement>().checkpoint = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                GetComponentInChildren<Animator>().SetTrigger("reached");
                FindObjectOfType<audiomanager>().playaudio("checkpoint");
                hasreached = true;
            }
        }
    }
}
