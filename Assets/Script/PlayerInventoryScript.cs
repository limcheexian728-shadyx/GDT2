using UnityEngine;
using TMPro;

public class PlayerInventoryScript : MonoBehaviour
{
    public int Cake;
    public int ChocolateCake;
    public int CakeWithCherry;
    public int ChocolateCakeWithCherry;
    public TMP_Text InventoryList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InventoryList.text = $"Inventory:\nCake: {Cake}\nChocolate Cake: {ChocolateCake}\n" +
        $"Cake with Cherry: {CakeWithCherry}\nChocolate Cake with Cherry: {ChocolateCakeWithCherry}";
    }
}
