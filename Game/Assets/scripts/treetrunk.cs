using UnityEngine;

public class treetrunk : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<audiomanager>().playaudio("treecrack");            
            tree.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }
}
