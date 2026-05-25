using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shopManager_script : MonoBehaviour
{
    public static shopManager_script instance;

    [Header("Pets")]
    List<pet_scriptable> all_pets = new List<pet_scriptable>();
    List<pet_scriptable> locked_pets = new List<pet_scriptable>();
    List<pet_scriptable> unlocked_pets = new List<pet_scriptable>();

    [Header("Shop Diplay")]
    [SerializeField] TMP_Text[] currencyDisplay;
    [SerializeField] GameObject shopItemPrefab;
    [SerializeField] Transform shopContainer;

    [Header("Upgrade Display")]
    [SerializeField] Sprite spaceSprite;
    [SerializeField] Sprite gainSprite;
    int spaceCost, gainCost;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        spaceCost = resourceManager_script.instance.availableSlots * 50;
        gainCost = resourceManager_script.instance.foodGain * 100;
        all_pets = scriptableHolder_script.instance.all_pets;
        Refresh();
        SetCoinDisplay();
    }

    public void SetCoinDisplay()
    {
        resourceManager_script.instance.Save();
        foreach (TMP_Text currentText in currencyDisplay)
        {
            currentText.text = resourceManager_script.instance.coins.ToString();
        }
    }

    public void Refresh()
    {
        SetCoinDisplay();
        locked_pets = new List<pet_scriptable>();
        unlocked_pets = new List<pet_scriptable>();

        foreach (Transform child in shopContainer)
        {
            Destroy(child.gameObject);
        }

        Instantiate(shopItemPrefab, shopContainer).GetComponent<shopItem_script>().SetShopItem(spaceSprite, spaceCost, -1);
        Instantiate(shopItemPrefab, shopContainer).GetComponent<shopItem_script>().SetShopItem(gainSprite, gainCost, -2);
        int i = 0;
        foreach (pet_scriptable pet in all_pets)
        {
            if (pet.IsUnlocked())
            {
                unlocked_pets.Add(pet);
            }
            else if (!pet.IsUnlocked())
            {
                locked_pets.Add(pet);
                if (i < 7)
                {
                    Instantiate(shopItemPrefab, shopContainer).GetComponent<shopItem_script>().SetShopItem(pet, i);
                    i++;
                }
            }
        }

        resourceManager_script.instance.unlockedPets = unlocked_pets;
        resourceManager_script.instance.RefreshActivePets();

        bakeryManager_script.instance.Refresh();
    }

    public void Buy(int index)
    {
        if (index == -1)
        {
            if (resourceManager_script.instance.Spend(spaceCost))
            {
                soundManager_script.instance.ButtonClicked();
                spaceCost = resourceManager_script.instance.BuyPetSpace();
            }
        }else if (index == -2)
        {
            if (resourceManager_script.instance.Spend(gainCost))
            {
                soundManager_script.instance.ButtonClicked();
                gainCost = resourceManager_script.instance.BuyFoodGain();
            }
        }
        else if (resourceManager_script.instance.Spend(locked_pets[index].GetCost()))
        {
            soundManager_script.instance.ButtonClicked();
            locked_pets[index].Unlock(true);
            locked_pets[index].SetEquip(false);
        }
        Refresh();
    }
}
