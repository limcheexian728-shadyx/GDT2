using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class equip_script : MonoBehaviour
{
    pet_scriptable petData;
    [SerializeField] Image displayImage;

    [Header("Display")]
    [SerializeField] Color equipColor;
    [SerializeField] Color unequipColor;
    [SerializeField] Image buttonImage;
    [SerializeField] TMP_Text buttonText;

    public void Setup(pet_scriptable pet_data)
    {
        petData = pet_data;

        displayImage.sprite = petData.sprite;
        StateChange();
    }

    public void Clicked()
    {
        if (resourceManager_script.instance.Equip(petData))
        {
            StateChange();
        }
    }

    void StateChange()
    {
        if (petData.IsEquiped())
        {
            buttonImage.color = unequipColor;
            buttonText.text = "Unequip";
        }
        else
        {
            buttonImage.color = equipColor;
            buttonText.text = "Equip";
        }
    }
}
