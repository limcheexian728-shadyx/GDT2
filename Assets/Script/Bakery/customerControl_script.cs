using System.Collections;
using UnityEngine;

public class customerControl_script : MonoBehaviour
{
    [SerializeField] customer_scriptable customerData;
    [SerializeField] float speed = 5;
    bool isDone;
    SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        isDone = false;
    }

    private void Update()
    {
        if (isDone)
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, speed * Time.deltaTime);

        if (transform.localScale.x < 0.01)
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
