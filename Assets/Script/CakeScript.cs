using TMPro;
using UnityEngine;

public class CakeScript : MonoBehaviour
{
    BakeryManager Chef;
    public int WhoAreYou;
    public TMP_Text serveText;
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
                        Chef.CakeAmount = true;
                    }
                    else
                    {
                        serveText.text = $"You have already make a cake you fucking dumbass";
                        serveText.gameObject.SetActive(true);
                    }
                break;
                }
            case 2:
                if (Chef.ChocolateJamAmount == false)
                {
                    Chef.ChocolateJamAmount = true;
                }
                else
                {
                    serveText.text = $"You have already added chocolate jam you fucking dumbass";
                    serveText.gameObject.SetActive(true);
                }
                break;
            case 3:
                if (Chef.CherryAmount == false)
                {
                    Chef.CherryAmount = true;
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
