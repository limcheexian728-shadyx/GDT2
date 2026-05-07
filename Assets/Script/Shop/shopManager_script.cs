using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shopManager_script : MonoBehaviour
{
    public static shopManager_script instance;

    [Header("Pets")]
    [SerializeField] List<pet_scriptable> all_pets = new List<pet_scriptable>();
    List<pet_scriptable> locked_pets = new List<pet_scriptable>();
    List<pet_scriptable> unlocked_pets = new List<pet_scriptable>();

    [Header("Shop Diplay")]
    [SerializeField] TMP_Text currencyDisplay;
    [SerializeField] GameObject shopItemPrefab;
    [SerializeField] Transform shopContainer;

    void Start()
    {
        instance = this;
        Refresh();
        SetCoinDisplay();
    }

    void Update()
    {
        
    }

    public void SetCoinDisplay()
    {
        currencyDisplay.text = resourceManager_script.instance.coins.ToString();
    }

    public void Refresh()
    {
        locked_pets = new List<pet_scriptable>();
        unlocked_pets = new List<pet_scriptable>();

        foreach (Transform child in shopContainer)
        {
            Destroy(child.gameObject);
        }

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
        if (resourceManager_script.instance.Spend(locked_pets[index].GetCost()))
        {
            locked_pets[index].Unlock();
            locked_pets[index].SetEquip(false);
            Refresh();
        }
    }
}
