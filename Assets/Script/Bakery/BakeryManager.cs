using TMPro;
using UnityEngine;


public class BakeryManager : MonoBehaviour
{
    //public PlayerInventoryScript playerInventory;
    public bool CakeAmount = false;
    public bool ChocolateJamAmount = false;
    public bool CherryAmount = false;
    public TMP_Text ServeText;

    private CustomerButtonScript customerOrders;

    private void Start()
    {
        customerOrders = GetComponent<CustomerButtonScript>();
        customerOrders.ShowCustomerOrder();
    }

    public void CookingCake()
    {
        if (CakeAmount)
        {
            CakeAmount = false;
            if (ChocolateJamAmount && CherryAmount)
            {
                ChocolateJamAmount = false;
                CherryAmount = false;
                ServeText.text = $"You had make a chocolate cake with cherry!!!";
                //playerInventory.ChocolateCakeWithCherry++;
            }
            else if (ChocolateJamAmount)
            {
                ChocolateJamAmount = false;
                ServeText.text = $"You had make a chocolate cake!!!";
                //playerInventory.ChocolateCake++;
            }
            else if (CherryAmount)
            {
                CherryAmount = false;
                ServeText.text = $"You had make a cake with cherry!!!";
                //playerInventory.CakeWithCherry++;
            }
            else
            {
                ServeText.text = $"You had make a cake!!!";
                //playerInventory.Cake++;
            }
            ServeText.gameObject.SetActive(true);
        }
        else
        {
            ServeText.text = $"You don't have enough cake to make this";
            ServeText.gameObject.SetActive(true);
        }
    }

}
