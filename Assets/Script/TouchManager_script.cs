using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TouchManager_script : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private Vector3 CLICKWHERE()
    {
        Vector3 mouseScreenPosition = input.actions[].ReadValue<Vector2>();
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    //private void OnClickPerformed(InputAction.CallbackContext context)
    //{
    //    print("mouse clicked");
    //    if (Physics.Raycast(GetMouseWorldPosition(), Vector3.forward, out RaycastHit hit))
    //    {
    //        if (hit.collider != null)
    //        {
    //            print(hit.collider.name);
    //            draggedObject = hit.collider.gameObject;
    //            initialObjectDistance = Vector3.Distance(transform.position, draggedObject.transform.position);
    //            offset = draggedObject.transform.position - GetMouseWorldPosition();
    //            StartCoroutine(DragRoutine());
    //        }
    //    }
    //}

    //private void OnClickCanceled(InputAction.CallbackContext context)
    //{
    //    // Stop dragging when the click is released
    //    if (draggedObject != null)
    //    {
    //        StopCoroutine(DragRoutine());
    //        draggedObject = null;
    //    }
    //}

    //private IEnumerator DragRoutine()
    //{
    //    // Continuously update object position while dragging
    //    while (draggedObject != null)
    //    {
    //        draggedObject.transform.position = GetMouseWorldPosition() + offset;
    //        yield return null;
    //    }
    //}

    //private Vector3 GetMouseWorldPosition()
    //{
    //    // Convert screen position to world position at the object's distance from the camera
    //    Vector3 mouseScreenPosition = positionAction.ReadValue<Vector2>();
    //    mouseScreenPosition.z = initialObjectDistance;
    //    return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    //}
}
