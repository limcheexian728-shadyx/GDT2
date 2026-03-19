using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Script : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
