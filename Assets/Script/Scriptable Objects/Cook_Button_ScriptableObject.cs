using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Cook_Button_Click",menuName ="Scriptable Object/Cook_Button_Click",order =1)]
public class Cook_Button_ScriptableObject : ScriptableObject
{
    public int Which_Level = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddScore()
    {
        if (Which_Level == 1)
        {
            Score_In_Level.Instance.PointsNeededLevel1 += 10;
            if(Score_In_Level.Instance.PointsNeededLevel1 == 300)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
