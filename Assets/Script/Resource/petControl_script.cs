using System.Collections;
using UnityEngine;

public class petControl_script : MonoBehaviour
{
    [SerializeField] pet_scriptable petData;
    [SerializeField] GameObject Indicator;

    float cooldown = 2;
    float currentCooldown = 0;
    int currentClickCount, amtGain = 1;
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
        StartCoroutine(EatCycle());
    }

    public void ActivatePet(int amt)
    {
        amtGain = amt;

        // May make it next time to have a loading bar so that clicks turn into progression to gain the resource
        currentClickCount++;
        if (currentClickCount == petData.GetClickCount())
        {
            GainResource();
            currentClickCount = 0;
        } 
    }

    public void GainResource()
    {
        for (int i = 0; i < petData.GetLevel(); i++)
        {
            int selection = Random.Range(0, petData.GetIngredients().Count);
            ingredient_scriptable ingredient = petData.GetIngredients()[selection];
            ingredient.Add(amtGain);
            print(ingredient.name + " --> " + amtGain.ToString());
            if (Indicator != null)
            {
                Instantiate(Indicator, transform.position, Quaternion.identity)
                    .GetComponent<indicator_script>()
                    .SetUpIndicator(ingredient.sprite, transform.position.y);
            }
        }
    }

    void Update()
    {
        Movement();
        DirectionHandling();
    }

    Vector3 GetRandomDirection()
    {
        float new_x = Random.Range(-1, 1.1f);
        float new_y = Random.Range(-1, 1.1f);
        return new Vector3(new_x, new_y, 0);
    }
    void DirectionHandling()
    {
        // Cooldown handling
        currentCooldown -= Time.deltaTime;
        if (currentCooldown > 0) { return; }

        // Changing the direction of the pet
        move_direction = 0.5f * Time.deltaTime * GetRandomDirection();
        currentCooldown = cooldown;
    }
    void Movement()
    {
        transform.Translate(move_direction);

        // Checking Position
        if (transform.position.x > -7 && transform.position.x < -3
            && transform.position.y > -3 && transform.position.y < 2.8f) 
            return;

        transform.Translate(-move_direction);
        move_direction *= -1;
    }

    IEnumerator EatCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(petData.GetEatCooldown());
            if (resourceManager_script.instance.EatFood(petData.GetConsumptionAmount())) 
            {
                GainResource();
                resourceManager_script.instance.UpdateUI();
            }
        }
    }
}
