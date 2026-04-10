using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TMP_Text text_ui;

    string current_text;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator Speech(string complete_text)
    {
        yield return new WaitForSeconds(0.01f);
    }
}
