using UnityEngine;

public class soundManager_script : MonoBehaviour
{
    public static soundManager_script instance;

    public int current_page;

    [SerializeField] AudioSource buttonClickSource;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        buttonClickSource.Play();
    }
}
