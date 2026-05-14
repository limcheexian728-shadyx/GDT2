using System.Collections;
using UnityEngine;

public class customerControl_script : MonoBehaviour
{
    [SerializeField] customer_scriptable customerData;
    [SerializeField] float speed = 5;
    bool isDone;
    SpriteRenderer sprite;
    Rigidbody2D body;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        isDone = false;
    }

    private void Update()
    {
        if (isDone)
        {
            body.simulated = false;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < -3.5f)
            Destroy(gameObject);
    }

    public void SetCustomer(customer_scriptable data)
    {
        customerData = data;
        sprite.sprite = customerData.customerSprite;
    }

    public void OrderComplete()
    {
        sprite.sortingOrder = 8;
        print("Order Complete");
        isDone = true;
    }

    public customer_scriptable GetCustomerData() { return customerData; }
}
