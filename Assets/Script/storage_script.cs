using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class storage_script : MonoBehaviour
{
    public static storage_script instance;
    [SerializeField] private bool reset = false;

    [Header("Currency")]
    private int coins;

    [Header("Resources")]
    [SerializeField] private int gain = 1;
    [SerializeField] ingredient_scriptable[] storageIngredients;
    [SerializeField] List<pet_scriptable> unlockedPets = new List<pet_scriptable>();
    [SerializeField] TMP_Text[] ui_texts;

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
        foreach (pet_scriptable pet in unlockedPets)
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
