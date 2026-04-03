using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] level_scriptable level;

    TMP_Text text;
    
    void Start()
    {
        text = gameObject.GetComponentInChildren<TMP_Text>();
    }
    
    public void SelectedLevel()
    {
        if (level.previousLevel != null)
        {
            if (level.previousLevel.score < level.scoreRequired)
            {
                text.SetText("Insufficient Points");
                return;
            }
        }
        text.SetText("Level Selected");
    }
}
