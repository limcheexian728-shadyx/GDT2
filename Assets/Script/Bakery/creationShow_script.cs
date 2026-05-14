using UnityEngine;

public class creationShow_script : MonoBehaviour
{
    [SerializeField] GameObject[] createDisplay;
    [SerializeField] float speed;
    [SerializeField] float liniency = 2;
    [SerializeField] float waitPositionY;
    bool isServed;
    Transform customer;

    void Start()
    {
        foreach (GameObject display in createDisplay)
            display.SetActive(false);
    }

    void Update()
    {
        if (isServed)
        {
            if (transform.position.y < waitPositionY)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (customer == null) Destroy(gameObject);
            else if ((transform.position - customer.position).magnitude < liniency)
            {
                transform.SetParent(customer.transform);
            }
        }
    }

    public void ShowIngredient(int index)
    {
        createDisplay[index].SetActive(true);
    }

    public void Serve(Transform customer)
    {
        this.customer = customer;
        isServed = true;
    }
}
