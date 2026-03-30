using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName ="Scene_Change",menuName ="Scriptable Object/Scene",order =1)]
public class Scene_Change_Script : ScriptableObject
{
    public int WhichLevelAreYou;
    public int NumberOfSceneInSetting;
    public Text MyTextObject;


    public void NextScene()
    {
        if (WhichLevelAreYou == 1)
        {
            SceneManager.LoadScene(NumberOfSceneInSetting);
        }
        else if (WhichLevelAreYou == 2)
        {
            if (Score_In_Level.Score_Level_1 == 100)
            {
                SceneManager.LoadScene(NumberOfSceneInSetting);
            }
            else
            {
                ShowTextOnClick();
            }
        }
    }

    public void ShowTextOnClick()
    {
        MyTextObject.text = "Not enough point";
    }
}
