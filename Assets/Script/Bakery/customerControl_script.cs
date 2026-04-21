using System.Collections;
using UnityEngine;

public class customerControl_script : MonoBehaviour
{
    [SerializeField] customer_scriptable customerData;
    [SerializeField] float distance = 15f;
    [SerializeField] Vector3 direction = Vector3.left;

    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        // Testing
        Move();
    }

    public void SetCustomer(customer_scriptable data)
    {
        customerData = data;
        sprite.sprite = data.customerSprite;
    }

    public void Move()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        for (int i = 0; i < 15; i++)
        {
            transform.position += direction.normalized * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
