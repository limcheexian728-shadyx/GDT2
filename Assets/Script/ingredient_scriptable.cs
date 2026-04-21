using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ingredient_scriptable", menuName = "Scriptable Objects/ingredient_scriptable")]
public class ingredient_scriptable : ScriptableObject
{
    public enum ingredients { base_cake, chocolate, cherry };

    [SerializeField] private ingredients type;
    [SerializeField] private int amount = 0;
    [SerializeField] private List<customer_scriptable> unlockableCustomer;

    public void Reset()
    {
        amount = 0;
        unlockableCustomer.Clear();
    }

    public void AddCustomer(customer_scriptable customer)
    {
        if (!unlockableCustomer.Contains(customer))
            unlockableCustomer.Add(customer);
    }

    public void Add(int amt) { amount += amt; }
    public void Remove(int amt) { amount -= amt; }
    public int GetAmount() { return amount; }
    public ingredients GetIngredient() {  return type; }
}
