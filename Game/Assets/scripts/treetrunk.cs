using UnityEngine;

public class treetrunk : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            tree.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }
}
