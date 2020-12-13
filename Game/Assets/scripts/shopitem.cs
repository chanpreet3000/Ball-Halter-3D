using UnityEngine;
using UnityEngine.UI;

public class shopitem : MonoBehaviour
{
    public Sprite itemphoto;
    public int itemnumber = 0, itemprice = 0;
    public string itemname = "noname";
    public Image itemimage, diamondimage;
    public Button purchasebtn, selectbtn;
    public Text nametext, pricetext, insuffientcreditstext, suffientcreditstext;
    public GameObject owned;
    public Toggle toggle;
    [SerializeField]
    private int isavailable = 0;

    private void Awake()
    {
        itemimage.sprite = itemphoto;
        nametext.text = itemname;
        pricetext.text = itemprice.ToString("0");
        selectbtn.GetComponent<Button>().onClick.AddListener(selectbtnclicked);      
        purchasebtn.GetComponent<Button>().onClick.AddListener(purchasebtnclicked);   
        if(PlayerPrefs.GetInt("skinnumber", 0) == itemnumber)
        {
            toggle.isOn = true;
        }
    }
    public void refreshpanel()
    {
        isavailable = PlayerPrefs.GetInt(itemname, 0);
        if (isavailable == 0)
        {
            purchasebtn.gameObject.SetActive(true);
            selectbtn.gameObject.SetActive(false);
            owned.SetActive(false);
            toggle.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("diamonds", 0) >= itemprice)
            {
                purchasebtn.interactable = true;
                insuffientcreditstext.gameObject.SetActive(false);
                suffientcreditstext.gameObject.SetActive(true);
            }
            else
            {
                purchasebtn.interactable = false;
                insuffientcreditstext.gameObject.SetActive(true);
                suffientcreditstext.gameObject.SetActive(false);
            }
        }
        else if (isavailable == 1)
        {
            purchasebtn.gameObject.SetActive(false);
            selectbtn.gameObject.SetActive(true);
            insuffientcreditstext.gameObject.SetActive(false);
            suffientcreditstext.gameObject.SetActive(false);
            diamondimage.gameObject.SetActive(false);
            pricetext.gameObject.SetActive(false);
            owned.SetActive(true);
            toggle.gameObject.SetActive(true);
        }       
    }
    public void selectbtnclicked()
    {
        toggle.isOn = true;
        togglebtnclicked(true);
    }    
    public void purchasebtnclicked()
    {
        PlayerPrefs.SetInt("diamonds", PlayerPrefs.GetInt("diamonds", 0) - itemprice);
        PlayerPrefs.SetInt(itemname, 1);
    }

    private void FixedUpdate()
    {        
        refreshpanel();
    }
    public void togglebtnclicked(bool value)
    {
        if(value)
        {
            PlayerPrefs.SetInt("skinnumber", itemnumber);
        }
        else
        {
            PlayerPrefs.SetInt("skinnumber", 0);
        }
    }
}
