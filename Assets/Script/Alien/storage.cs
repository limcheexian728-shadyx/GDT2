using UnityEngine;
using static ingredient_scriptable;

public class storage : MonoBehaviour
{
    [SerializeField] private int gain = 1;
    [SerializeField] ingredient_scriptable[] storageIngredients;

    [Header("Debug")]
    [SerializeField] private bool reset = false;

    void Start()
    {
        if (reset) { for (int i = 0; i < storageIngredients.Length; i++) { storageIngredients[i].Reset(); } }
    }

    public bool GetItem(ingredient_scriptable.ingredients item)
    {
        for (int i = 0; i < storageIngredients.Length; i++)
        {
            if (storageIngredients[i].GetIngredient() == item)
            {
                if (storageIngredients[i].GetAmount() <= 0)
                    return false;
                storageIngredients[i].Remove(1);
                return true;
            }
        }
        return false;
    }

    public void Clicked()
    {
        for (int i = 0; i < gain; i++)
        {
            int selection = Random.Range(0, storageIngredients.Length);
            storageIngredients[selection].Add(1);
            print(storageIngredients[selection].name + " - " + storageIngredients[selection].GetAmount());
        }
    }
}
