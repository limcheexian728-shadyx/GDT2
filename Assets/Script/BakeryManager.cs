using TMPro;
using UnityEngine;


public class BakeryManager : MonoBehaviour
{
    public PlayerInventoryScript playerInventory;
    public int CakeAmount;
    public int ChocolateJamAmount;
    public int CherryAmount;
    public TMP_Text ServeText;

    public void CookingCake()
    {
        if (CakeAmount > 0)
        {
            CakeAmount -= 1;
            if (ChocolateJamAmount > 0 && CherryAmount > 0)
            {
                ChocolateJamAmount -= 1;
                CherryAmount -= 1;
                ServeText.text = $"You had make a chocolate cake with cherry!!!";
                playerInventory.ChocolateCakeWithCherryAmount++;
            }
            else if (ChocolateJamAmount > 0)
            {
                ChocolateJamAmount -= 1;
                ServeText.text = $"You had make a chocolate cake!!!";
                playerInventory.ChocolateCakeAmount++;
            }
            else if (CherryAmount > 0)
            {
                CherryAmount -= 1;
                ServeText.text = $"You had make a cake with cherry!!!";
                playerInventory.CakeWithCherryAmout++;
            }
            else
            {
                ServeText.text = $"You had make a cake!!!";
                playerInventory.CakeAmount++;
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
