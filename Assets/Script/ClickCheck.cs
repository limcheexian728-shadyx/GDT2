using UnityEngine;

public class ClickCheck : MonoBehaviour
{
    public TouchManager_script manager_Script;

    private GameObject inTrigger;

    private void OnEnable()
    {
        manager_Script.SetHeld(inTrigger.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = collision.gameObject;
    }
}
