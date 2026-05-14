using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "pet_scriptable", menuName = "Scriptable Objects/pet_scriptable")]
public class pet_scriptable : ScriptableObject
{
    [Header("Basics")]
    public Sprite sprite;
    [SerializeField] List<ingredient_scriptable> ingredients;
    [Header("Resource")]
    [SerializeField] int maxLevel= 5;
    [SerializeField] int level = 1;
    [SerializeField] int clickCount = 5;
    [Header("Shop Value")]
    [SerializeField] bool isUnlocked;
    [SerializeField] bool isEquiped;
    [SerializeField] int cost = 10;
    [Header("Hunger")]
    [SerializeField] int consumeAmount;
    [SerializeField] float eatCooldown = 0.5f;

    public int GetCost() {  return cost; }
    public int GetClickCount() {  return clickCount; }
    public int GetLevel() {  return level; }
    public int GetConsumptionAmount() {  return consumeAmount; }
    public float GetEatCooldown() {  return eatCooldown; }
    public bool IsUnlocked() { return isUnlocked; }
    public bool IsEquiped() { return isEquiped; }
    public List<ingredient_scriptable> GetIngredients() { return ingredients; }

    public void Unlock() {  isUnlocked = true; }
    public void SetEquip(bool state) { isEquiped = state; }
    public void LevelUp()
    {
        level += 1;
        if (level > maxLevel)
            level = maxLevel;
    }

}
