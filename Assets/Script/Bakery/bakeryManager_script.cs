using System.Collections.Generic;
using UnityEngine;
using static ingredient_scriptable;


public class bakeryManager_script : MonoBehaviour
{
    public static bakeryManager_script instance;

    [Header("Spawn Customer")]
    [SerializeField] GameObject customerPrefab; // the customer body
    [SerializeField] Transform spawnPoint; // where to spawn the customer
    [SerializeField] List<customer_scriptable> customers; // potential customers that can be added into the queue

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

        // Spawning the customer and setting its value
        currentCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity, spawnPoint).GetComponent<customerControl_script>();
        int customerIndex = Random.Range(0, customers.Count);
        while (customerIndex == previousCustomerIndex) { customerIndex = Random.Range(0, customers.Count); }
        previousCustomerIndex = customerIndex;
        currentCustomer.SetCustomer(customers[customerIndex]);

        // Getting the data from the customer
        currenCustomerOrder = currentCustomer.GetCustomerData().GetOrder();
        print("Customer orders a " + currenCustomerOrder.GetName());
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
        if (!ingredientsSelected.Contains(item) && storage_script.instance.GetItem(item))
        {
            // Adding the ingredient into the selection to check with order later
            ingredientsSelected.Add(item);
            // Making the display visible for feedback
            createDisplay[index].SetActive(true);
        }
    }

    public void Serve()
    {
        Sprite display;
        if (currenCustomerOrder.CheckRecipe(ingredientsSelected))
        {
            storage_script.instance.GainCoin(currenCustomerOrder.GetPrice());
            // Customer happy
            display = successOrder;
        }
        else
        {
            // Customer unhappy
            display = failOrder;
        }

        Instantiate(Indicator, spawnPoint.position, Quaternion.identity)
            .GetComponent<indicator_script>()
            .SetUpIndicator(display, spawnPoint.position.y);

        Destroy(currentCustomer.gameObject);
        SummonCustomer();
    }
}
