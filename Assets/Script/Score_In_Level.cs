using UnityEngine;

public class Score_In_Level : MonoBehaviour
{
    public static Score_In_Level Instance;
    public int PointsNeededLevel1 = 0;

    private void Start()
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
