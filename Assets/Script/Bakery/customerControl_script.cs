using System.Collections;
using UnityEngine;

public class customerControl_script : MonoBehaviour
{
    [SerializeField] customer_scriptable customerData;
    [SerializeField] float speed, distance = 3f;
    [SerializeField] Vector3 direction = Vector3.left;
    Vector3 targetPosition;

    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void SetCustomer(customer_scriptable data)
    {
        customerData = data;
        sprite.sprite = customerData.customerSprite;
    }

    public customer_scriptable GetCustomerData() { return customerData; }

    public void Move()
    {
        targetPosition += direction * distance;
    }

    public void Served(bool correctOrder)
    {
        if (correctOrder)
        {

        }
        else
        {

        }
    }
}
