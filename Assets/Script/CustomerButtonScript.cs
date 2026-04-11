using UnityEngine;
using TMPro;

public class CustomerButtonScript : MonoBehaviour
{
    public TMP_Text CustomerOrderText;
    public CustomerOrderManager CustomerBoss;

    public void ShowCustomerOrder()
    {
        string[] CustomerCakeOrderArray = { "cake", "chocolate cake", "cake with cherry", "chocolate cake with cherry" };
        int CustomerOrderRand = Random.Range(1, 4);//For customer to order multiple items
        CustomerOrderText.text = $"I want a ";
        for (int i = 0; i < CustomerOrderRand; i++)
        {
            int ArrayRand = Random.Range(0, CustomerCakeOrderArray.Length);//For customer randomly order item/s in array
            if (i > 0)//If customer order more than 1 items put a "&" between items 
            {
                CustomerOrderText.text += "& ";
            }
             switch (ArrayRand)//Check which item in array customer orders
            {
                case 3:
                    CustomerOrderText.text += $"{CustomerCakeOrderArray[ArrayRand]} ";
                    CustomerBoss.ChocolateCakeWithCherry++;
                    CustomerOrderText.gameObject.SetActive(true);
                    break;
                case 2:
                    CustomerOrderText.text += $"{CustomerCakeOrderArray[ArrayRand]} ";
                    CustomerBoss.CakeWithCherry++;
                    CustomerOrderText.gameObject.SetActive(true);
                    break;
                case 1:
                    CustomerOrderText.text += $"{CustomerCakeOrderArray[ArrayRand]} ";
                    CustomerBoss.ChocolateCake++;
                    CustomerOrderText.gameObject.SetActive(true);
                    break;
                case 0:
                    CustomerOrderText.text += $"{CustomerCakeOrderArray[ArrayRand]} ";
                    CustomerBoss.Cake++;
                    CustomerOrderText.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
