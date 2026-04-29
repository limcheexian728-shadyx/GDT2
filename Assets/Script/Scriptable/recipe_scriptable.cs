using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "recipe_scriptable", menuName = "Scriptable Objects/recipe_scriptable")]
public class recipe_scriptable : ScriptableObject
{
    [SerializeField] private string recipeName = "Default";
    [SerializeField] private List<ingredient_scriptable.ingredients> ingredients;
    [SerializeField] private int price = 10;

    public string GetName() { return recipeName; }
    public int GetPrice() { return price; }

    public List<ingredient_scriptable.ingredients> GetList() { return ingredients; }

    public bool CheckRecipe(List<ingredient_scriptable.ingredients> check)
    {
        // check has more than or less than ingredients required so it cannot be this recipe
        if (check.Count != ingredients.Count) return false;
        // if check doesnt contain one of the ingredient then it cannot be this recipe
        for (int i  = 0; i < ingredients.Count; i++)
            if (!check.Contains(ingredients[i])) return false;
        // yes.
        return true;
    }
}
