using UnityEngine;

public class FoodLogic : MonoBehaviour
{
    int foodCounter = 0;
    public Sprite beforeCook;
    public Sprite afterCook;
    public Sprite cooking;
    public Sprite strawberryCake;
    SpriteRenderer currentSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishCOokingMiniGame()
    {
        UpdatePicture(2);
    }

    public void UpdatePicture(int currentFoodStatus)
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
