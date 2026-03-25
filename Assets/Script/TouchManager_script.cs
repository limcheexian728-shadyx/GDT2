using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TouchManager_script : MonoBehaviour
{
    private InputAction clickAction;
    private InputAction positionAction;
    private Camera mainCamera;
    private GameObject draggedObject;
    private Vector3 offset;
    private float initialObjectDistance;

    // Reference your Input Action Asset in the Inspector
    public InputActionAsset inputActionAsset;

    private void Awake()
    {
        mainCamera = Camera.main;
        // Find the actions by name from the asset
        clickAction = inputActionAsset.FindActionMap("Player").FindAction("Click");
        positionAction = inputActionAsset.FindActionMap("Player").FindAction("Position");

        clickAction.performed += OnClickPerformed;
        clickAction.canceled += OnClickCanceled;
    }

    private void OnEnable()
    {
        clickAction.Enable();
        positionAction.Enable();
    }

    private void OnDisable()
    {
        clickAction.Disable();
        positionAction.Disable();
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        print("mouse clicked");
        if (Physics.Raycast(GetMouseWorldPosition(), Vector3.forward, out RaycastHit hit))
        {
            if (hit.collider != null)
            {
                print(hit.collider.name);
                draggedObject = hit.collider.gameObject;
                initialObjectDistance = Vector3.Distance(transform.position, draggedObject.transform.position);
                offset = draggedObject.transform.position - GetMouseWorldPosition();
                StartCoroutine(DragRoutine());
            }
        }
    }

    private void OnClickCanceled(InputAction.CallbackContext context)
    {
        // Stop dragging when the click is released
        if (draggedObject != null)
        {
            StopCoroutine(DragRoutine());
            draggedObject = null;
        }
    }

    private IEnumerator DragRoutine()
    {
        // Continuously update object position while dragging
        while (draggedObject != null)
        {
            draggedObject.transform.position = GetMouseWorldPosition() + offset;
            yield return null;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Convert screen position to world position at the object's distance from the camera
        Vector3 mouseScreenPosition = positionAction.ReadValue<Vector2>();
        mouseScreenPosition.z = initialObjectDistance;
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
