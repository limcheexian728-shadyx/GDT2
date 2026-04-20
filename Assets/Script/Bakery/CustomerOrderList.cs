using UnityEngine;
using TMPro;

public class CustomerOrderList : MonoBehaviour
{
    public TMP_Text List;
    public CustomerOrderManager OrderManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        List.text = $"Order:\nCake: {OrderManager.Cake}\nChocolate Cake: {OrderManager.ChocolateCake}\n" +
        $"Cake with Cherry: {OrderManager.CakeWithCherry}\nChocolate Cake with Cherry: {OrderManager.ChocolateCakeWithCherry}";
    }
}
