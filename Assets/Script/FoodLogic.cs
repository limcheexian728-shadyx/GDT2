using UnityEngine;

public class FoodLogic : MonoBehaviour
{
    int foodCounter = 0;
    public Sprite beforeCook;
    public Sprite afterCook;
    public Sprite cooking;
    public Sprite strawberryCake;
    SpriteRenderer currentSprite;
    Cook_Button_ScriptableObject myBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myBoss = GameObject.FindGameObjectWithTag("Serve").GetComponent<Cook_Button_ScriptableObject>();
    }

    public void FinishCOokingMiniGame()
    {
        UpdateFoodStatus(2);
    }

    public void UpdateFoodStatus(int currentFoodStatus)
    {
        switch (currentFoodStatus)
        {
            case 1:
                currentSprite.sprite = cooking;
                break;
            case 0:
                currentSprite.sprite = beforeCook;
                break;
            default:
                break;
        }
    }
}
