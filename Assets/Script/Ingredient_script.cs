using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Ingredient_script : MonoBehaviour
{
    [SerializeField] Ingredient_Type type;
    
    private Vector3 _offset;
    private DepositArea_script deposit;


    private void OnMouseDown()
    {
        _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print("Clicked");
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    private void OnMouseUp()
    {
        if (deposit != null)
        {
            deposit.Recieved(type);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.TryGetComponent<DepositArea_script>(out deposit);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<DepositArea_script>(out DepositArea_script check_deposit))
            if (check_deposit == deposit)
                deposit = null;
    }
}
