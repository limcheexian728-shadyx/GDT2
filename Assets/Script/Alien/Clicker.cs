using System.Collections;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private int gain = 1;
    [SerializeField] private ingredient_scriptable[] ingredients;
    [SerializeField] private bool reset = false;

    void Start()
    {
        if (reset) { for (int i = 0; i < ingredients.Length; i++) { ingredients[i].Reset(); } }
    }

    public void Clicked()
    {
        for (int i = 0; i < gain; i++)
        {
            int selection = Random.Range(0, ingredients.Length);
            ingredients[selection].Add(1);
            print(ingredients[selection].name + " - " + ingredients[selection].GetAmount());
        }
    }
}
