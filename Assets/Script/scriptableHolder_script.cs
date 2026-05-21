using System.Collections.Generic;
using UnityEngine;

public class scriptableHolder_script : MonoBehaviour
{
    public static scriptableHolder_script instance;

    [SerializeField] bool reset = false;

    public List<ingredient_scriptable> storageIngredients;
    public List<customer_scriptable> customers;
    public List<pet_scriptable> all_pets;

    private void Awake()
    {
        instance = this;

        if (reset)
        {
            PlayerPrefs.SetInt("CurrencySaved", 0);
            PlayerPrefs.SetInt("SlotsSaved", 3);
            PlayerPrefs.Save();

            for (int i = 0; i < storageIngredients.Count; i++)
                storageIngredients[i].Reset();

            foreach (var pet in all_pets)
            {
                if (!pet.isStarter) pet.Unlock(false);
                else pet.Unlock(true);
            }
        }
    }
}
