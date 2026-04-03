using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Scene_Change_Script : MonoBehaviour
{
    public int WhichLevelAreYou;
    public int NumberOfSceneInSetting;
    public TMP_Text MyTextObject;


    public void NextScene(string nextSceneName)
    {
        switch (nextSceneName)
        {
            case "MainMenu":
                SceneManager.LoadScene("LevelSelect");
                break;
            case "Quit":
                Application.Quit();
                break;
            case "Level_1":
                SceneManager.LoadScene(nextSceneName);
                break;
            case "Level_2":
                if (Score_In_Level.Instance.PointsNeededLevel1 >= 100)
                    SceneManager.LoadScene(nextSceneName);
                else
                    ShowTextOnClick();
                    break;
            default:
                break;
        }
    }

    public void ShowTextOnClick()
    {
        MyTextObject.gameObject.SetActive(true);
        MyTextObject.text = "Not enough point";
    }
}
