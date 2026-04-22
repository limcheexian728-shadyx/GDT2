using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "pet_scriptable", menuName = "Scriptable Objects/pet_scriptable")]
public class pet_scriptable : ScriptableObject
{
    public Sprite sprite;

    [SerializeField] private List<ingredient_scriptable> ingredients;
    [SerializeField] private List<customer_scriptable> unlockableCustomer;
    [SerializeField] int cost = 10;
    [SerializeField] int maxLevel= 5;
    [SerializeField] private bool isUnlocked;
    private int level;

    public void ActivatePet(int amt)
    {
        for (int i = 0; i < amt; i++)
        {
            int selection = Random.Range(0, ingredients.Count);
            ingredients[selection].Add(level);
        }
    }

    public void AddCustomer(customer_scriptable customer)
    {
        if (!unlockableCustomer.Contains(customer))
            unlockableCustomer.Add(customer);
    }

    public bool IsUnlocked() { return isUnlocked; }

    public void LevelUp()
    {
        level += 1;
        if (level > maxLevel)
            level = maxLevel;
    }

    public bool IsMaxLevel() {  return maxLevel == level; }

    public int GetCost() {  return cost; }
}
