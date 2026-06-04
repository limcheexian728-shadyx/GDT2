using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scriptableHolder_script : MonoBehaviour
{
    public static scriptableHolder_script instance;

    [SerializeField] bool reset = false;
    [SerializeField] tutorialControl_script tutorialControl;

    public List<ingredient_scriptable> storageIngredients;
    public List<customer_scriptable> customers;
    public List<pet_scriptable> all_pets;

    private void Awake()
    {
        instance = this;

        if (reset || !PlayerPrefs.HasKey("SlotsSaved"))
        {
            tutorialControl.SetupTutorial();
            PlayerPrefs.SetInt("CurrencySaved", 0);
            PlayerPrefs.SetInt("SlotsSaved", 3);
            PlayerPrefs.Save();

            for (int i = 0; i < storageIngredients.Count; i++)
                storageIngredients[i].Reset();

            foreach (var pet in all_pets)
            {
                if (!pet.isStarter) pet.Unlock(false);
                else pet.Unlock(true);
            }
        }
    }
}

#if UNITY_EDITOR
public class DeletePlayerPrefsScript : EditorWindow
{
    [MenuItem("Window/Delete PlayerPrefs (All)")]
    static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs have been deleted.");
    }
}
#endif