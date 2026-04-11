using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//[CreateAssetMenu(fileName = "Cook_Button_Click",menuName ="Scriptable Object/Cook_Button_Click",order =1)]
public class Cook_Button_ScriptableObject : MonoBehaviour/*ScriptableObject*/
{
    public BakeryManager Chef;
    public CustomerOrderManager customerOrderBoss;
    public int Which_Level_Button_Are_You = 0;
    public TMP_Text ServeText;
    public CustomerButtonScript customerOrders;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DetectScore()//I think this probably maybe ke neng boleh remove since it seems a bit useless without level selection
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
        if (customerOrderBoss.Cake > 0 && Chef.CakeAmount == true)//check if custormer got order this item or not and if the button/s to make this item is clicked or not
        {
            customerOrderBoss.Cake--;//minus the order from the customer
            Chef.CakeAmount = false;//set cake button "unclick"
            ServeText.text = $"You had serve a cake!!!";//words come out
            ServeText.gameObject.SetActive(true);
            //Score_In_Level.Instance.PointsNeededLevel1 += 10;//Will change to get money
        }
       else if (customerOrderBoss.ChocolateCake > 0 && Chef.ChocolateJamAmount == true && Chef.CakeAmount == true)//check if custormer got order this item or not and if the button/s to make this item is clicked or not
        {
            customerOrderBoss.ChocolateCake--;
            Chef.CakeAmount = false;
            Chef.ChocolateJamAmount = false;
            ServeText.text = $"You had serve a chocolate cake!!!";
            ServeText.gameObject.SetActive(true);
            //Score_In_Level.Instance.PointsNeededLevel1 += 25;
        }
        else if (customerOrderBoss.CakeWithCherry > 0 && Chef.CakeAmount == true && Chef.CherryAmount == true)//check if custormer got order this item or not and if the button/s to make this item is clicked or not
        {
            customerOrderBoss.CakeWithCherry--;
            Chef.CakeAmount = false;
            Chef.CherryAmount = false;
            ServeText.text = $"You had serve a cake with cherry!!!";
            ServeText.gameObject.SetActive(true);
            //Score_In_Level.Instance.PointsNeededLevel1 += 15;
        }
        else if (customerOrderBoss.ChocolateCakeWithCherry > 0 && Chef.ChocolateJamAmount == true && Chef.CakeAmount == true && Chef.ChocolateJamAmount == true && Chef.CherryAmount == true)//check if custormer got order this item or not and if the button/s to make this item is clicked or not
        {
            customerOrderBoss.ChocolateCakeWithCherry--;
            Chef.CakeAmount = false;
            Chef.ChocolateJamAmount = false;
            Chef.CherryAmount = false;
            ServeText.text = $"You had serve a chocolate cake with cherry!!!";
            ServeText.gameObject.SetActive(true);
            //Score_In_Level.Instance.PointsNeededLevel1 += 40;
        }
        else//fail to serve customer orders and all the things will hilang
        {
            Chef.CakeAmount = false;
            Chef.ChocolateJamAmount = false;
            Chef.CherryAmount = false;
            ServeText.text = $"You fail to serve the customer, you mtfking failure!!!";
            ServeText.gameObject.SetActive(true);
            customerOrderBoss.Cake = 0;
            customerOrderBoss.ChocolateCake = 0;
            customerOrderBoss.CakeWithCherry = 0;
            customerOrderBoss.ChocolateCakeWithCherry = 0;
            customerOrders.ShowCustomerOrder();
        }
    }

    public void CheckCustomerOrderList()
    {
        if (customerOrderBoss.Cake == 0 && customerOrderBoss.ChocolateCake == 0 && customerOrderBoss.CakeWithCherry == 0 && customerOrderBoss.ChocolateCakeWithCherry == 0)
        {
            customerOrders.ShowCustomerOrder();//show next customer order
        }
    }
}
