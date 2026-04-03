using UnityEngine;
using TMPro;

public class CustomerButtonScript : MonoBehaviour
{
    public TMP_Text CustomerOrderText;
    public CustomerOrderManager CustomerBoss;

    public void ShowCustomerOrder()
    {
        string[] CustomerCakeOrderArray = { "cake", "chocolate cake", "cake with cherry", "chocolate cake with cherry" };
        int rand = Random.Range(0, CustomerCakeOrderArray.Length);
        switch (rand)
        {
            case 3:
                CustomerOrderText.text = $"I want a {CustomerCakeOrderArray[rand]}";
                CustomerBoss.ChocolateCakeWithCherry++;
                CustomerOrderText.gameObject.SetActive(true);
                break;
            case 2:
                CustomerOrderText.text = $"I want a {CustomerCakeOrderArray[rand]}";
                CustomerBoss.CakeWithCherry++;
                CustomerOrderText.gameObject.SetActive(true);
                break;
            case 1:
                CustomerOrderText.text = $"I want a {CustomerCakeOrderArray[rand]}";
                CustomerBoss.ChocolateCake++;
                CustomerOrderText.gameObject.SetActive(true);
                break;
            case 0:
                CustomerOrderText.text = $"I want a {CustomerCakeOrderArray[rand]}";
                CustomerBoss.Cake++;
                CustomerOrderText.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
