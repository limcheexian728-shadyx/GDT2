using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
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
    // Has Appeared
    [SerializeField] private bool isAppeared;
    // Rarity (Weight: higher = higher chance to get spawned)
    [SerializeField] private int weight = 1;

    public bool CheckState(List<pet_scriptable> unlockedList)
    {
        for (int i = 0; i < requiredUnlocks.Count; i++)
        {
            if (!unlockedList.Contains(requiredUnlocks[i]))
                return false;
        }
        return true;
    }

    public bool GetAppeared() {  return isAppeared; }
    public int getWeight() { return weight; }

    public recipe_scriptable GetOrder()
    {
        return possibleOrders[Random.Range(0, possibleOrders.Count)];
    }
}
