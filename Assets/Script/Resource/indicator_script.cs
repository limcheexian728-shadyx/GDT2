using UnityEngine;

public class indicator_script : MonoBehaviour
{
    float kill_y;

    public void SetUpIndicator(Sprite sprite, float set_y)
    {
        kill_y = set_y;
        GetComponent<SpriteRenderer>().sprite = sprite;
        GetComponent<Rigidbody2D>().linearVelocity = new Vector3(Random.Range(-1, 1), 3, 0);
    }

    void Update()
    {
        if (transform.position.y < kill_y) { Destroy(gameObject); }
    }
}
