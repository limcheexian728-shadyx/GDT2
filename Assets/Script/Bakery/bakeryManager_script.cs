using System;
using System.Collections.Generic;
using UnityEngine;


public class bakeryManager_script : MonoBehaviour
{
    public static bakeryManager_script instance;

    [Header("Spawn Customer")]
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] Transform spawnPoint;
    private List<GameObject> customerObjects;
    private List<customer_scriptable> customers; // potential customers that can be added into the queue
    private List<customer_scriptable> queue; // so that can spawn a queue that reflects customers coming in
    public event Action nextCustomerSignal;

    [Header("Order Handler")]
    private GameObject currentCustomerObject;
    private recipe_scriptable currenCustomerOrder;
    private List<ingredient_scriptable.ingredients> ingredientsSelected;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < 5; i++)
        {
            AddCustomer();
        }
    }

    public void Trash() { ingredientsSelected.Clear(); }

    void AddCustomer()
    {
        // Getting customer data
        customer_scriptable newCustomer = customers[UnityEngine.Random.Range(0, customers.Count)];
        queue.Add(newCustomer);
        // Instantiate the customer prefab
        GameObject newCustomerObject = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
        customerObjects.Add(newCustomerObject);
        // Get the customer control script to set the customer with the customer data
        customerControl_script newCustomerScript = newCustomerObject.GetComponent<customerControl_script>();
        nextCustomerSignal += newCustomerScript.Move;
    }

    void NextCustomer()
    {
        // Get order and remove the customer from queue
        currenCustomerOrder = queue[0].GetOrder();
        queue.RemoveAt(0);
        // addding a new customer to the queue so theres more customers to load
    }

    public void AddIngredient(ingredient_scriptable.ingredients item)
    {
        // Checks if the storage has enough of the item
        if (storage_script.instance.GetItem(item))
            // Adding the ingredient into the selection to check with order later
            ingredientsSelected.Add(item);
    }

    public void Serve()
    {
        if (currenCustomerOrder.CheckRecipe(ingredientsSelected))
        {
            storage_script.instance.GainCoin(currenCustomerOrder.GetPrice());
            // Customer happy
        }
        else
        {
            // Customer unhappy
        }
        // Customer leave
        Destroy(currentCustomerObject);
        Trash(); // Clear the order
    }
}
