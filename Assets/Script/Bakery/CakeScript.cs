using TMPro;
using UnityEngine;
using static ingredient_scriptable;

public class CakeScript : MonoBehaviour
{
    BakeryManager Chef;
    public int WhoAreYou;
    public TMP_Text serveText;
    public storage StoreRoom;
    ingredient_scriptable.ingredients base_cake;
    ingredient_scriptable.ingredients chocolate;
    ingredient_scriptable.ingredients cherry;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Chef = GameObject.FindGameObjectWithTag("Chef").GetComponent<BakeryManager>();
    }

    public void Onclick()
    {
        switch (WhoAreYou)
        {
            case 0:
                break;
            case 1:
                {
                    if (Chef.CakeAmount == false)
                    {
                        if (StoreRoom.GetItem(base_cake))
                        {
                            Chef.CakeAmount = true;
                        }
                        else
                        {
                            serveText.text = $"DIU LEI LOU MOU!!! You don't have enough cake resource";
                            serveText.gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        serveText.text = $"You have already make a cake you fucking dumbass";
                        serveText.gameObject.SetActive(true);
                    }
                break;
                }
            case 2:
                if (Chef.ChocolateJamAmount == false )
                {
                    if (StoreRoom.GetItem(chocolate))
                    {
                    Chef.ChocolateJamAmount = true;
                    }
                    else
                    {
                        serveText.text = $"DIU LEI LOU MOU!!! You don't have enough chocolate jam resource";
                        serveText.gameObject.SetActive(true);
                    }
                }
                else
                {
                    serveText.text = $"You have already added chocolate jam you fucking dumbass";
                    serveText.gameObject.SetActive(true);
                }
                break;
            case 3:
                if (Chef.CherryAmount == false )
                {
                    if(StoreRoom.GetItem(cherry))
                    {
                    Chef.CherryAmount = true;
                    }
                    else
                    {
                        serveText.text = $"DIU LEI LOU MOU!!! You don't have enough cherry resource";
                        serveText.gameObject.SetActive(true);
                    }
                }
                else
                {
                    serveText.text = $"You have already addded cherry you fucking dumbass";
                    serveText.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}
