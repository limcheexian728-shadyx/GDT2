using TMPro;
using UnityEngine;

public class Score_In_Level : MonoBehaviour
{
    public static Score_In_Level Instance;
    public int PointsNeededLevel1 = 0;
    public TMP_Text ScoreUI1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
