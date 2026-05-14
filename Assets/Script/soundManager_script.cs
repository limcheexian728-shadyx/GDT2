using UnityEngine;

public class soundManager_script : MonoBehaviour
{
    public static soundManager_script instance;

    public int current_page;
    
    AudioSource buttonClickSource;

    void Awake()
    {
        instance = this;
        buttonClickSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        buttonClickSource.Play();
    }
}
