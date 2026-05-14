using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class shopManager_script : MonoBehaviour
{
    public static shopManager_script instance;

    [Header("Pets")]
    [SerializeField] List<pet_scriptable> all_pets = new List<pet_scriptable>();
    List<pet_scriptable> locked_pets = new List<pet_scriptable>();
    List<pet_scriptable> unlocked_pets = new List<pet_scriptable>();

    [Header("Shop Diplay")]
    [SerializeField] TMP_Text[] currencyDisplay;
    [SerializeField] GameObject shopItemPrefab;
    [SerializeField] Transform shopContainer;

    public void Awake()
    {
        instance = this;
    }

    public void ResetValues()
    {
        foreach (var pet in all_pets)
        {
            if (!pet.isStarter)
            {
                pet.Unlock(false);
            }
            else
            {
                pet.Unlock(true);
            }
        }
    }

    void Start()
    {
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

        Instantiate(shopItemPrefab, shopContainer).GetComponent<shopItem_script>().SetShopItem(null, -1);
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
                if (i < 9)
                {
                    Instantiate(shopItemPrefab, shopContainer).GetComponent<shopItem_script>().SetShopItem(pet, i);
                    i++;
                }
            }
        }

        resourceManager_script.instance.unlockedPets = unlocked_pets;
        resourceManager_script.instance.Refresh();

        bakeryManager_script.instance.Refresh();
    }

    public void Buy(int index)
    {
        if (index == -1)
        {
            if (resourceManager_script.instance.Spend(100))
            {
                soundManager_script.instance.ButtonClicked();
                resourceManager_script.instance.BuyPetSpace();
            }
        }else if (resourceManager_script.instance.Spend(locked_pets[index].GetCost()))
        {
            soundManager_script.instance.ButtonClicked();
            locked_pets[index].Unlock(true);
            locked_pets[index].SetEquip(false);
        }
        Refresh();
    }
}
