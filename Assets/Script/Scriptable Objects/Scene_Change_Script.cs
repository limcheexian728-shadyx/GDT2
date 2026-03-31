using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//[CreateAssetMenu(fileName ="Scene_Change",menuName ="Scriptable Object/Scene",order =1)]
public class Scene_Change_Script : MonoBehaviour//ScriptableObject
{
    public int WhichLevelAreYou;
    public int NumberOfSceneInSetting;
    public TMP_Text MyTextObject;


    public void NextScene(string nextSceneName)
    {
        switch (nextSceneName)
        {
            case "Level_2":
                if (Score_In_Level.Instance.PointsNeededLevel1 == 100)
                    SceneManager.LoadScene(nextSceneName);
                else
                    ShowTextOnClick();
                    break;
            case "Level_1":
                SceneManager.LoadScene(nextSceneName);
                break;
            default:
                break;
        }
        //if (WhichLevelAreYou == 1)
        //{
        //    SceneManager.LoadScene(NumberOfSceneInSetting);
        //}
        //else if (WhichLevelAreYou == 2)
        //{
        //    if (Score_In_Level.Instance.Score_Level_1 == 100)
        //    {
        //        SceneManager.LoadScene(NumberOfSceneInSetting);
        //    }
        //    else
        //    {
        //        ShowTextOnClick();
        //    }
        //}


    }

    public void ShowTextOnClick()
    {
        //coroutine start
        MyTextObject.gameObject.SetActive(true);
        MyTextObject.text = "Not enough point";
        //coroutine check and wait 5 second then continue
        MyTextObject.gameObject.SetActive(false);
    }
}
