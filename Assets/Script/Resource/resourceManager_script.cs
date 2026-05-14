using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ingredient_scriptable;

public class resourceManager_script : MonoBehaviour
{
    public static resourceManager_script instance;
    [SerializeField] bool reset = false;

    [Header("Currency")]
    public int coins;

    [Header("Resources")]
    [SerializeField] int foodGain = 10;
    [SerializeField] TMP_Text currentFoodCountText;
    [SerializeField] ingredient_scriptable[] storageIngredients;
    [SerializeField] TMP_Text[] ui_texts;
    int currentFoodCount;

    [Header("Pet Handling")]
    [SerializeField] GameObject petPrefab;
    [SerializeField] Transform petContainer;

    [HideInInspector] public List<pet_scriptable> unlockedPets = new List<pet_scriptable>();

    List<petControl_script> petObjects = new List<petControl_script>();


    [Header("Equip Handling")]
    public int availableSlots = 3;
    [SerializeField] equip_script equipPrefab;
    [SerializeField] GameObject nextButton, prevButton;
    [SerializeField] Transform equipTab, equipContainer;

    List<pet_scriptable> equipedPets = new List<pet_scriptable>();
    int equipPage = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (reset)
        {
            shopManager_script.instance.ResetValues();

            PlayerPrefs.SetInt("CurrencySaved", coins);
            PlayerPrefs.SetInt("SlotsSaved", availableSlots);
            PlayerPrefs.Save();
            for (int i = 0; i < storageIngredients.Length; i++)
            {
                storageIngredients[i].Reset();
            }
        }
        if (PlayerPrefs.HasKey("CurrencySaved"))
            coins = PlayerPrefs.GetInt("CurrencySaved");
        if (PlayerPrefs.HasKey("SlotsSaved"))
            availableSlots = PlayerPrefs.GetInt("SlotsSaved");
        UpdateUI();
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform pet in petContainer)
        {
            Destroy(pet.gameObject);
        }

        RefreshEquipPage();

        petObjects.Clear();
        foreach (pet_scriptable pet in equipedPets)
        {
            GameObject newPet = Instantiate(petPrefab, petContainer.position, Quaternion.identity, petContainer);
            petControl_script newPetControl = newPet.GetComponent<petControl_script>();
            newPetControl.SetPet(pet);
            petObjects.Add(newPetControl);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrencySaved", coins);
        PlayerPrefs.SetInt("SlotsSaved", availableSlots);
        PlayerPrefs.Save();
    }

    // Handling Equip
    public bool Equip(pet_scriptable pet)
    {
        // if the pet is not equipped
        // check if there is available space for this pet
        if (!pet.IsEquiped() && equipedPets.Count < availableSlots)
        {
            // equip pet
            pet.SetEquip(true);
            // add to the list
            equipedPets.Add(pet);
            // Set the pets
            Refresh();
            return true;
        }

        // if the pet is equipped
        // if the pet is the last pet equipped
        if (pet.IsEquiped() && equipedPets.Count > 1)
        {
            // unequip pet
            pet.SetEquip(false);
            // remove from the list
            equipedPets.Remove(pet);
            // Set the pets
            Refresh();
            return true;
        }
        return false;
    }
    public void RefreshEquipPage()
    {
        print("page refreashed");
        foreach (Transform child in equipContainer)
        {
            Destroy(child.gameObject);
        }

        equipedPets = new();
        foreach (pet_scriptable pet in unlockedPets)
        {
            if (pet.IsEquiped()) equipedPets.Add(pet);
            else if (equipedPets.Contains(pet)) equipedPets.Remove(pet);
        }

        for (int i = 0; i < 9; i++)
        {
            if (i + equipPage < unlockedPets.Count)
            {
                Instantiate(equipPrefab, equipContainer).Setup(unlockedPets[i + equipPage]);
            }
        }

        print(unlockedPets.Count - (9 * equipPage));
        if (unlockedPets.Count - (9 * equipPage) > 9) nextButton.SetActive(true);
        else nextButton.SetActive(false);

        if (equipPage > 0) prevButton.SetActive(true);
        else prevButton.SetActive(false);
    }
    public void NextPage(bool state)
    {
        // equip page will not go until there is a page with nothing on it
        if (state && equipPage + 9 < unlockedPets.Count)
            equipPage++;
        // stop the page from going into error territory
        else if (equipPage != 0)
            equipPage--;
        RefreshEquipPage();
    }
    public void BuyPetSpace()
    {
        availableSlots++;
    }

    // Handling Currency
    public void GainCoin(int amount) { coins += amount; }
    public bool Spend(int amount)
    {
        // Player a broke-y
        if (coins < amount) return false;
        // Player has enough coins and can spend
        coins -= amount;
        return true;
    }

    // Handling Resources
    public bool GetItem(ingredients item)
    {
        for (int i = 0; i < storageIngredients.Length; i++)
        {
            if (storageIngredients[i].GetIngredient() == item)
            {
                if (storageIngredients[i].GetAmount() <= 0)
                    return false;
                storageIngredients[i].Remove(1);
                UpdateUI();
                return true;
            }
        }
        return false;
    }
    public void Clicked()
    {
        currentFoodCount += foodGain;
        UpdateUI();
    }
    public bool EatFood(int amount)
    {
        if (currentFoodCount <= amount) return false;

        print("Food Eaten");
        currentFoodCount -= amount;
        return true;
    }
    public void UpdateUI()
    {
        currentFoodCountText.text = "Fud lef: " + currentFoodCount.ToString();
        for (int i = 0; i < storageIngredients.Length; i++)
        {
            string amount = storageIngredients[i].GetAmount().ToString();
            ui_texts[i].SetText(amount);
            ui_texts[i + 6].SetText(amount);
        }
    }

    public ingredient_scriptable Convert(ingredients input)
    {
        if (input == ingredients.strawberry) return storageIngredients[1];
        if (input == ingredients.cherry) return storageIngredients[2];
        if (input == ingredients.whiteChocolate) return storageIngredients[3];
        if (input == ingredients.milkChocolate) return storageIngredients[4];
        if (input == ingredients.darkChocolate) return storageIngredients[5];
        return storageIngredients[0];
    }
}
