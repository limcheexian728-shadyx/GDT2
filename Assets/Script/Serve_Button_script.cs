using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//[CreateAssetMenu(fileName = "Cook_Button_Click",menuName ="Scriptable Object/Cook_Button_Click",order =1)]
public class Cook_Button_ScriptableObject : MonoBehaviour/*ScriptableObject*/
{
    public PlayerInventoryScript playerInventory;
    public CustomerOrderManager customerOrderBoss;
    public int Which_Level_Button_Are_You = 0;
    public TMP_Text ServeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DetectScore()
    {
        switch (Which_Level_Button_Are_You)
        {
            case(0):
                break;
            case(1):
                if (Score_In_Level.Instance.PointsNeededLevel1 >= 300)
                {
                    SceneManager.LoadScene(1);
                }
                break;
            default:
                break;
        }
        //if (Which_Level_Button_Are_You == 1)
        //{
        //    Score_In_Level.Instance.PointsNeededLevel1 += 10;
        //    if(Score_In_Level.Instance.PointsNeededLevel1 == 300)
        //    {
        //        SceneManager.LoadScene(1);
        //    }
        //}
    }

    public void ServeCustomer()
    {
        if (customerOrderBoss.Cake > 0 && playerInventory.CakeAmount > 0)
        {
            customerOrderBoss.Cake--;
            playerInventory.CakeAmount--;
            ServeText.text = $"You had serve a cake!!!";
            ServeText.gameObject.SetActive(true);
            Score_In_Level.Instance.PointsNeededLevel1 += 10;
        }
       else if (customerOrderBoss.ChocolateCake > 0 && playerInventory.ChocolateCakeAmount > 0)
        {
            customerOrderBoss.ChocolateCake--;
            playerInventory.ChocolateCakeAmount--;
            ServeText.text = $"You had serve a chocolate cake!!!";
            ServeText.gameObject.SetActive(true);
            Score_In_Level.Instance.PointsNeededLevel1 += 25;
        }
        else if (customerOrderBoss.CakeWithCherry > 0 && playerInventory.CakeWithCherryAmout > 0)
        {
            customerOrderBoss.CakeWithCherry--;
            playerInventory.CakeWithCherryAmout--;
            ServeText.text = $"You had serve a cake with cherry!!!";
            ServeText.gameObject.SetActive(true);
            Score_In_Level.Instance.PointsNeededLevel1 += 15;
        }
        else if (customerOrderBoss.ChocolateCakeWithCherry > 0 && playerInventory.ChocolateCakeWithCherryAmount > 0)
        {
            customerOrderBoss.ChocolateCakeWithCherry--;
            playerInventory.ChocolateCakeWithCherryAmount--;
            ServeText.text = $"You had serve a chocolate cake with cherry!!!";
            ServeText.gameObject.SetActive(true);
            Score_In_Level.Instance.PointsNeededLevel1 += 40;
        }
        else
        {
            ServeText.text = $"You fail to serve the customer, you mtfking failure!!!";
            ServeText.gameObject.SetActive(true);
        }
    }
}
