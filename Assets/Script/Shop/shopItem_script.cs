using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shopItem_script : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text costText;

    public void SetShopItem(pet_scriptable petData, int index)
    {
        itemImage.sprite = petData.sprite;
        costText.text = petData.GetCost().ToString();
        GetComponent<Button>().onClick.AddListener(() => shopManager_script.instance.Buy(index));
    }
}
