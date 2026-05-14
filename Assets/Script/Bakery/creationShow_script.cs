using UnityEngine;

public class creationShow_script : MonoBehaviour
{
    [SerializeField] GameObject[] createDisplay;
    void Start()
    {
        foreach (GameObject display in createDisplay)
            display.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowIngredient(int index)
    {
        createDisplay[index].SetActive(true);
    }
}
