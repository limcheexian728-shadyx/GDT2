using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    [SerializeField] Transform equipTab, equipContainer;
    [SerializeField] float tabSpeed = 5;

    List<pet_scriptable> equipedPets = new List<pet_scriptable>();
    int equipPage = 0;

    private void Awake()
    {
        instance = this;

        if (reset) 
        { 
            for (int i = 0; i < storageIngredients.Length; i++) 
            { 
                storageIngredients[i].Reset();
            } 
        }
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
    public bool GetItem(ingredient_scriptable.ingredients item)
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
}
