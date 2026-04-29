using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shopItem_script : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text costText;
    int shopItemIndex;

    public void SetShopItem(pet_scriptable petData, int index)
    {
        shopItemIndex = index;
        itemImage.sprite = petData.sprite;
        costText.text = petData.GetCost().ToString();
    }


}
