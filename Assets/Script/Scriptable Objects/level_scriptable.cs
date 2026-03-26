using UnityEngine;

[CreateAssetMenu(fileName = "level_scriptable", menuName = "Scriptable Objects/level_scriptable")]
public class level_scriptable : ScriptableObject
{
    public int level = 0;
    public level_scriptable previousLevel;
    public int scoreRequired = 100;

    [Header("Level Items")]
    public food_scriptable[] food_list;
}
