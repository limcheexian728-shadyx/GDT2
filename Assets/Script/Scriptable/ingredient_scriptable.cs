using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ingredient_scriptable", menuName = "Scriptable Objects/ingredient_scriptable")]
public class ingredient_scriptable : ScriptableObject
{
    public enum ingredients { baseCake, strawberry, cherry, darkChocolate, milkChocolate, whiteChocolate };

    public Sprite sprite;
    [SerializeField] private ingredients type;
    [SerializeField] private int amount = 0;

    public void Reset()
    {
        amount = 0;
    }

    public void Add(int amt) { amount += amt; }
    public void Remove(int amt) { amount -= amt; }
    public int GetAmount() { return amount; }
    public ingredients GetIngredient() {  return type; }
}
