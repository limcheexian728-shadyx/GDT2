using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "pet_scriptable", menuName = "Scriptable Objects/pet_scriptable")]
public class pet_scriptable : ScriptableObject
{
    public Sprite sprite;

    [SerializeField] List<ingredient_scriptable> ingredients;
    [SerializeField] int cost = 10;
    [SerializeField] int maxLevel= 5;
    [SerializeField] int level = 1;
    [SerializeField] bool isUnlocked;
    [SerializeField] int clickCount = 5;

    public bool IsUnlocked() { return isUnlocked; }
    public void Unlock() {  isUnlocked = true; }
    public int GetLevel() {  return level; }
    public List<ingredient_scriptable> GetIngredients() { return ingredients; }
    public bool IsMaxLevel() {  return maxLevel == level; }
    public int GetCost() {  return cost; }
    public int GetClickCount() {  return clickCount; }

    public void LevelUp()
    {
        level += 1;
        if (level > maxLevel)
            level = maxLevel;
    }

}
