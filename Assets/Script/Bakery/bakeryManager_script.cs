using System.Collections.Generic;
using UnityEngine;
using static ingredient_scriptable;


public class bakeryManager_script : MonoBehaviour
{
    public static bakeryManager_script instance;

    [Header("Spawn Customer")]
    [SerializeField] customerControl_script customerPrefab; // the customer body
    [SerializeField] Transform spawnPoint; // where to spawn the customer
    List<customer_scriptable> customers;
    List<customer_scriptable> potentialCustomers = new(); // potential customers that can be added into the queue

    [Header("Feedback")]
    [SerializeField] AudioClip fail;
    [SerializeField] AudioClip success;
    AudioSource soundPlayer;

    [Header("Order Display")]
    [SerializeField] GameObject[] orderDisplay;
    [SerializeField] GameObject Indicator;
    [SerializeField] Sprite successOrder;
    [SerializeField] Sprite failOrder;

    [Header("Creation Display")]
    [SerializeField] creationShow_script createDisplayPrefab;
    [SerializeField] Transform creationPosition;
    [SerializeField] Sprite trash;
    creationShow_script currentCreateDisplay;

    [Header("Order Handler")]
    customerControl_script currentCustomer;
    recipe_scriptable currenCustomerOrder;
    List<ingredients> ingredientsSelected = new List<ingredients>();
    int previousCustomerIndex;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        customers = scriptableHolder_script.instance.customers;
        soundPlayer = GetComponent<AudioSource>();
        Refresh();
        Remove();
        SummonCustomer();
    }

    public void Trash()
    {
        if (ingredientsSelected.Count == 0) return;
        soundManager_script.instance.ButtonClicked();
        Remove();
        // Spawn Feedback for trash
        Instantiate(Indicator, creationPosition.position, Quaternion.identity)
            .GetComponent<indicator_script>()
            .SetUpIndicator(trash, creationPosition.position.y);
    }

    void Remove()
    {
        // Remove all display
        if (currentCreateDisplay != null) Destroy(currentCreateDisplay.gameObject);
        currentCreateDisplay = Instantiate(createDisplayPrefab, creationPosition.position, Quaternion.identity, creationPosition);
        // Clear the ingredient selected for a new hand
        ingredientsSelected.Clear();
    }

    void SummonCustomer()
    {
        // Spawning the customer
        currentCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

        // Setting the Customer Data
        int customerIndex = Random.Range(0, potentialCustomers.Count);
        while (customerIndex == previousCustomerIndex) { customerIndex = Random.Range(0, potentialCustomers.Count); }
        previousCustomerIndex = customerIndex;
        currentCustomer.SetCustomer(potentialCustomers[customerIndex]);

        // Getting the order from the customer
        currenCustomerOrder = currentCustomer.GetCustomerData().GetOrder();
        List<ingredients> items = currenCustomerOrder.GetList();
        foreach (GameObject item in orderDisplay) { item.SetActive(false); }
        if (items.Contains(ingredients.baseCake))
        {
            orderDisplay[0].SetActive(true);
            orderDisplay[6].SetActive(true);
        }
        if (items.Contains(ingredients.cherry))
        {
            orderDisplay[1].SetActive(true);
            orderDisplay[7].SetActive(true);
        }
        if (items.Contains(ingredients.strawberry))
        {
            orderDisplay[2].SetActive(true);
            orderDisplay[8].SetActive(true);
        }
        if (items.Contains(ingredients.whiteChocolate))
        {
            orderDisplay[3].SetActive(true);
            orderDisplay[9].SetActive(true);
        }
        if (items.Contains(ingredients.milkChocolate))
        {
            orderDisplay[4].SetActive(true);
            orderDisplay[10].SetActive(true);
        }
        if (items.Contains(ingredients.darkChocolate))
        {
            orderDisplay[5].SetActive(true);
            orderDisplay[11].SetActive(true);
        }
    }

    public void AddIngredient(int index)
    {
        // Changing from index to ingredient_scriptable.ingredients
        ingredients item = ingredients.baseCake;
        switch (index) {
            case 1: item = ingredients.cherry; break;
            case 2: item = ingredients.strawberry; break;
            case 3: item = ingredients.whiteChocolate; break;
            case 4: item = ingredients.milkChocolate; break;
            case 5: item = ingredients.darkChocolate; break;
        }

        // Checks if the storage has enough of the item
        if (!ingredientsSelected.Contains(item) && resourceManager_script.instance.GetItem(item))
        {
            // Adding the ingredient into the selection to check with order later
            ingredientsSelected.Add(item);
            // Making the display visible for feedback
            currentCreateDisplay.ShowIngredient(index);
        }
    }

    public void Serve()
    {
        if (ingredientsSelected.Count == 0) return;

        currentCreateDisplay.Serve(currentCustomer.transform);
        currentCreateDisplay = null;

        soundManager_script.instance.ButtonClicked();

        Sprite display;
        if (currenCustomerOrder.CheckRecipe(ingredientsSelected))
        {
            resourceManager_script.instance.GainCoin(currenCustomerOrder.GetPrice());
            // Customer happy
            display = successOrder;
            soundPlayer.resource = success;
            soundPlayer.Play();
        }
        else
        {
            resourceManager_script.instance.GainCoin(-currenCustomerOrder.GetPrice());
            // Customer unhappy
            display = failOrder;
            soundPlayer.resource = fail;
            soundPlayer.Play();
        }

        Instantiate(Indicator, currentCustomer.transform.position, Quaternion.identity)
            .GetComponent<indicator_script>()
            .SetUpIndicator(display, currentCustomer.transform.position.y);

        shopManager_script.instance.SetCoinDisplay();
        currentCustomer.OrderComplete();
        Remove();
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
