using UnityEngine;

public class petControl_script : MonoBehaviour
{
    [SerializeField] pet_scriptable petData;
    [SerializeField] GameObject Indicator;

    float cooldown = 2;
    float currentCooldown;
    SpriteRenderer sprite;
    Vector3 move_direction;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void SetPet(pet_scriptable pet)
    {
        petData = pet;
        sprite.sprite = pet.sprite;
    }

    public void ActivatePet(int amt)
    {
        petData.ActivatePet(amt);
    }

    void Update()
    {
        // Moving the pet
        transform.Translate(move_direction);
        CheckPosition();

        // Cooldown handling
        currentCooldown -= Time.deltaTime;
        if (currentCooldown > 0) { return; }
        
        // Changing the direction of the pet
        move_direction = 0.5f * Time.deltaTime * GetRandomDirection();
        currentCooldown = cooldown;
    }

    Vector3 GetRandomDirection()
    {
        float new_x = Random.Range(-1, 1.1f);
        float new_y = Random.Range(-1, 1.1f);
        return new Vector3(new_x, new_y, 0);
    }

    void CheckPosition()
    {
        if (transform.position.x > -7 && transform.position.x < -3
            && transform.position.y > -3 && transform.position.y < 4) 
            return;

        transform.Translate(-move_direction);
        move_direction *= -1;
    }
}
