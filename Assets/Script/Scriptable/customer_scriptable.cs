using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "customer_scriptable", menuName = "Scriptable Objects/customer_scriptable")]
public class customer_scriptable : ScriptableObject
{
    // Looks
    public Sprite customerSprite;
    // List of Orders
    [SerializeField] private List<recipe_scriptable> possibleOrders;
    // Unlocked
    [SerializeField] private List<pet_scriptable> requiredUnlocks;
    private bool isUnlocked;
    // Has Appeared
    private bool isAppeared;
    // Rarity (Weight: higher = higher chance to get spawned)
    [SerializeField] private float weight;

    public void SetPets()
    {
        for (int i = 0; i < requiredUnlocks.Count; i++)
        {
            requiredUnlocks[i].AddCustomer(this);
        }
    }

    public bool CheckState(List<pet_scriptable> unlockedList)
    {
        if (isUnlocked)
            return true;

        for (int i = 0; i < requiredUnlocks.Count; i++)
        {
            if (!unlockedList.Contains(requiredUnlocks[i]))
                return false;
        }
        isUnlocked = true;
        return true;
    }

    public bool GetAppeared() {  return isAppeared; }

    public recipe_scriptable GetOrder()
    {
        return possibleOrders[Random.Range(0, possibleOrders.Count)];
    }
}
