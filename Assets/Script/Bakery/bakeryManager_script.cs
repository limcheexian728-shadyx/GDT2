using System.Collections.Generic;
using UnityEngine;
using static ingredient_scriptable;


public class bakeryManager_script : MonoBehaviour
{
    public static bakeryManager_script instance;

    [Header("Spawn Customer")]
    [SerializeField] customerControl_script customerPrefab; // the customer body
    [SerializeField] Transform spawnPoint; // where to spawn the customer
    [SerializeField] List<customer_scriptable> customers;
    List<customer_scriptable> potentialCustomers = new(); // potential customers that can be added into the queue

    [Header("Order Display")]
    [SerializeField] GameObject[] orderDisplay;
    [SerializeField] GameObject[] createDisplay;
    [SerializeField] GameObject Indicator;
    [SerializeField] Sprite successOrder;
    [SerializeField] Sprite failOrder;
    [SerializeField] Sprite trash;

    [Header("Order Handler")]
    customerControl_script currentCustomer;
    recipe_scriptable currenCustomerOrder;
    List<ingredient_scriptable.ingredients> ingredientsSelected = new List<ingredient_scriptable.ingredients>();
    int previousCustomerIndex;

    private void Awake()
    {
        instance = this;
        Refresh();
    }

    private void Start()
    {
        Remove();
        SummonCustomer();
    }

    public void Trash()
    {
        if (ingredientsSelected.Count == 0) return;
        Remove();
        // Spawn Feedback for trash
        Instantiate(Indicator, createDisplay[0].transform.position, Quaternion.identity)
            .GetComponent<indicator_script>()
            .SetUpIndicator(trash, createDisplay[0].transform.position.y);
    }

    void Remove()
    {
        // Remove all display
        foreach (GameObject display in createDisplay) { display.SetActive(false); }
        // Clear the ingredient selected for a new hand
        ingredientsSelected.Clear();
    }

    void SummonCustomer()
    {
        Remove(); // Clear the order

        // Spawning the customer
        currentCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

        // Setting the Customer Data
        int customerIndex = Random.Range(0, potentialCustomers.Count);
        while (customerIndex == previousCustomerIndex) { customerIndex = Random.Range(0, potentialCustomers.Count); }
        previousCustomerIndex = customerIndex;
        currentCustomer.SetCustomer(potentialCustomers[customerIndex]);

        // Getting the order from the customer
        currenCustomerOrder = currentCustomer.GetCustomerData().GetOrder();
        List<ingredient_scriptable.ingredients> items = currenCustomerOrder.GetList();
        foreach (GameObject item in orderDisplay) { item.SetActive(false); }
        if (items.Contains(ingredient_scriptable.ingredients.baseCake)) orderDisplay[0].SetActive(true);
        if (items.Contains(ingredient_scriptable.ingredients.cherry)) orderDisplay[1].SetActive(true);
        if (items.Contains(ingredient_scriptable.ingredients.strawberry)) orderDisplay[2].SetActive(true);
        if (items.Contains(ingredient_scriptable.ingredients.whiteChocolate)) orderDisplay[3].SetActive(true);
        if (items.Contains(ingredient_scriptable.ingredients.milkChocolate)) orderDisplay[4].SetActive(true);
        if (items.Contains(ingredient_scriptable.ingredients.darkChocolate)) orderDisplay[5].SetActive(true);
    }

    public void AddIngredient(int index)
    {
        // Changing from index to ingredient_scriptable.ingredients
        ingredient_scriptable.ingredients item = ingredient_scriptable.ingredients.baseCake;
        switch (index) {
            case 1: item = ingredient_scriptable.ingredients.cherry; break;
            case 2: item = ingredient_scriptable.ingredients.strawberry; break;
            case 3: item = ingredient_scriptable.ingredients.whiteChocolate; break;
            case 4: item = ingredient_scriptable.ingredients.milkChocolate; break;
            case 5: item = ingredient_scriptable.ingredients.darkChocolate; break;
        }

        // Checks if the storage has enough of the item
        if (!ingredientsSelected.Contains(item) && resourceManager_script.instance.GetItem(item))
        {
            // Adding the ingredient into the selection to check with order later
            ingredientsSelected.Add(item);
            // Making the display visible for feedback
            createDisplay[index].SetActive(true);
        }
    }

    public void Serve()
    {
        if (ingredientsSelected.Count == 0) return;

        Sprite display;
        if (currenCustomerOrder.CheckRecipe(ingredientsSelected))
        {
            resourceManager_script.instance.GainCoin(currenCustomerOrder.GetPrice());
            // Customer happy
            display = successOrder;
        }
        else
        {
            // Customer unhappy
            display = failOrder;
        }

        Instantiate(Indicator, currentCustomer.transform.position, Quaternion.identity)
            .GetComponent<indicator_script>()
            .SetUpIndicator(display, currentCustomer.transform.position.y);

        currentCustomer.OrderComplete();
        SummonCustomer();
    }

    public void Refresh()
    {
        potentialCustomers.Clear();
        List<pet_scriptable> unlockedPets = resourceManager_script.instance.unlockedPets;
        foreach (customer_scriptable customer in customers)
        {
            if (customer.CheckState(unlockedPets))
            {
                for (int i = 0; i < customer.getWeight(); i++)
                    potentialCustomers.Add(customer);
            }
        }
    }
}
