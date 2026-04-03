using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;
    bool isDragged = false;
    Vector3 mousePosition;

    private void Update()
    {
        if (isDragged)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = mousePosition + offset;
        }
    }

    public void DragStart()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        offset = transform.position - mousePosition;
        isDragged = true;
    }

    public void DragStop()
    {
        isDragged = false;
    }
}
