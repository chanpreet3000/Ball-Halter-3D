using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class diamond : MonoBehaviour
{
    public int levelno=1;
    public GameObject d;
    private int amount = 10;
    private float localtime=0f;
    private void Awake()
    {        
        if(PlayerPrefs.GetInt("diamondnumber" + SceneManager.GetActiveScene().name, 0) == 1)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.transform.position = Vector3.Lerp(transform.parent.transform.position, other.transform.position, localtime);
            d.transform.localScale = Vector3.Lerp(d.transform.localScale, Vector3.zero, localtime);
            localtime += Time.deltaTime;
        }
        if(localtime>0.9f)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("diamondnumber" + SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.SetInt("diamonds", PlayerPrefs.GetInt("diamonds", 0) + amount);
            Analytics.CustomEvent("DiamondsTaken");
        }      
    }
}
