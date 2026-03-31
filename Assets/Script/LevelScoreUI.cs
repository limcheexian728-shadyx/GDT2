using UnityEngine;
using TMPro;

public class LevelScoreUI : MonoBehaviour
{
    public TMP_Text ScoreUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*ScoreUI.text = Score_In_Level.Instance.PointsNeededLevel1.ToString();*/
        ScoreUI.text = $"{Score_In_Level.Instance.PointsNeededLevel1}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
