using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//[CreateAssetMenu(fileName = "Cook_Button_Click",menuName ="Scriptable Object/Cook_Button_Click",order =1)]
public class Cook_Button_ScriptableObject : MonoBehaviour/*ScriptableObject*/
{
    public int Which_Level_Button_Are_You = 0;
    public TMP_Text ServeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddScore()
    {
        switch (Which_Level_Button_Are_You)
        {
            case(0):
                break;
            case(1):
                if (Score_In_Level.Instance.PointsNeededLevel1 == 300)
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
}
