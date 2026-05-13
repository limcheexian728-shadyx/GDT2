using UnityEngine;

public class creationShow_script : MonoBehaviour
{
    [SerializeField] GameObject[] createDisplay;
    void Start()
    {
        
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
