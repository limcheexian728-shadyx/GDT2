using NUnit.Framework;
using TMPro;
using UnityEngine;

public class BakeryManager : MonoBehaviour
{
    public int CakeAmount;
    public int ChocolateJamAmount;
    public int CherryAmount;
    public TMP_Text ServeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CookingCake()
    {
        if (CakeAmount > 0)
        {
            CakeAmount -= 1;
            if (ChocolateJamAmount > 0 && CherryAmount > 0)
            {
                ChocolateJamAmount -= 1;
                CherryAmount -= 1;
                ServeText.text = $"You had serve a chocolate cake with cherry!!!";
                Score_In_Level.Instance.PointsNeededLevel1 += 50;
            }
            else if (ChocolateJamAmount > 0)
            {
                ChocolateJamAmount -= 1;
                ServeText.text = $"You had serve a chocolate cake!!!";
                Score_In_Level.Instance.PointsNeededLevel1 += 25;
            }
            else if (CherryAmount > 0)
            {
                CherryAmount -= 1;
                ServeText.text = $"You had serve a cake with cherry!!!";
                Score_In_Level.Instance.PointsNeededLevel1 += 15;
            }
            else
            {
                ServeText.text = $"You had serve a cake!!!";
                Score_In_Level.Instance.PointsNeededLevel1 += 10;
            }
            ServeText.gameObject.SetActive(true);
        }
        else
        {
            ServeText.text = $"You don't have enough cake to make this";
            ServeText.gameObject.SetActive(true);
        }
    }

}
