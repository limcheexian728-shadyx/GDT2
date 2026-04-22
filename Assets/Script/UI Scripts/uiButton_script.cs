using UnityEngine;

public class uiButton_script : MonoBehaviour
{
    [SerializeField] float originalScale = 1.5f;
    [SerializeField] float hoverScale = 2f;
    [SerializeField] float speed = 3f;
    Vector3 targetScale = Vector3.one;

    private void Start()
    {
        targetScale = Vector3.one * originalScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
    }

    public void MouseEnter()
    {
        targetScale = Vector3.one * hoverScale;
    }

    public void MouseExit()
    {
        targetScale = Vector3.one * originalScale;
    }
}
