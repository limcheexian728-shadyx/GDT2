using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class storage_script : MonoBehaviour
{
    public static storage_script instance;
    [SerializeField] bool reset = false;

    [Header("Currency")]
    int coins;

    [Header("Resources")]
    [SerializeField] int gain = 1;
    [SerializeField] ingredient_scriptable[] storageIngredients;
    [SerializeField] TMP_Text[] ui_texts;

    [Header("Pet Handling")]
    [SerializeField] GameObject petPrefab;
    [SerializeField] Transform petContainer;
    [SerializeField] List<pet_scriptable> unlockedPets = new List<pet_scriptable>();
    List<petControl_script> petObjects = new List<petControl_script>();

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

        foreach (pet_scriptable pet in unlockedPets)
        {
            GameObject newPet = Instantiate(petPrefab, petContainer.position, Quaternion.identity, petContainer);
            petControl_script newPetControl = newPet.GetComponent<petControl_script>();
            newPetControl.SetPet(pet);
            petObjects.Add(newPetControl);
        }
        UpdateUI();
    }

    // Handling Currency
    public void GainCoin(int amount) { coins += amount; }
    public bool Spend(int amount)
    {
        // Player a broke-y
        if (coins < amount)
            return false;
        // Player has enough coins and can spend
        coins -= amount;
        return true;
    }

    // Handing Resources
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
        foreach (petControl_script pet in petObjects)
        {
            pet.ActivatePet(gain);
        }
        UpdateUI();
    }
    void UpdateUI()
    {
        for (int i = 0;i < storageIngredients.Length; i++)
            ui_texts[i].SetText(storageIngredients[i].GetAmount().ToString());
    }
}
