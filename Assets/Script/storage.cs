using TMPro;
using UnityEngine;
using static ingredient_scriptable;

public class storage : MonoBehaviour
{
    [SerializeField] private int gain = 1;
    [SerializeField] ingredient_scriptable[] storageIngredients;
    [SerializeField] TMP_Text[] ui_texts;

    [Header("Debug")]
    [SerializeField] private bool reset = false;

    private void Awake()
    {
        if (reset) 
        { 
            for (int i = 0; i < storageIngredients.Length; i++) 
            { 
                storageIngredients[i].Reset();
            } 
        }
        UpdateUI();
    }

    void Start()
    {
    }

    public bool GetItem(ingredient_scriptable.ingredients item)
    {
        for (int i = 0; i < storageIngredients.Length; i++)
        {
            if (storageIngredients[i].GetIngredient() == item)
            {
                if (storageIngredients[i].GetAmount() <= 0)
                    return false;
                storageIngredients[i].Remove(1);
                UpdateUI();
                return true;
            }
        }
        return false;
    }

    public void Clicked()
    {
        for (int i = 0; i < gain; i++)
        {
            int selection = Random.Range(0, storageIngredients.Length);
            storageIngredients[selection].Add(1);
            print(storageIngredients[selection].name + " - " + storageIngredients[selection].GetAmount());
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0;i < storageIngredients.Length; i++)
            ui_texts[i].SetText(storageIngredients[i].GetAmount().ToString());
    }
}
