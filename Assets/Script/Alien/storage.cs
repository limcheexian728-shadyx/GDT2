using UnityEngine;

public class storage : MonoBehaviour
{
    [SerializeField] ingredient_scriptable[] storageIngredients;

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
}
