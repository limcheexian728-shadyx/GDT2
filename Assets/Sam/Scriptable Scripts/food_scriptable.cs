using UnityEngine;

public enum Ingredient_Type { Test_1, Test_2, Test_3 }

[CreateAssetMenu(fileName = "food_scriptable", menuName = "Scriptable Objects/food_scriptable")]
public class food_scriptable : ScriptableObject
{
    public Ingredient_Type[] ingredient_steps;
}
