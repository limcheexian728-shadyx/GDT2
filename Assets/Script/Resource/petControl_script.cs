using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class petControl_script : MonoBehaviour
{
    [SerializeField] pet_scriptable petData;
    [SerializeField] GameObject Indicator;

    float cooldown = 2;
    float currentCooldown = 0;
    int amtGain = 1;
    SpriteRenderer sprite;
    AudioSource petsounds;
    Vector3 move_direction;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        petsounds = GetComponent<AudioSource>();
    }

    public void SetPet(pet_scriptable pet)
    {
        petData = pet;
        sprite.sprite = pet.sprite;
        StartCoroutine(EatCycle());
    }

    public void GainResource()
    {
        petsounds.Play();
        for (int i = 0; i < petData.GetLevel(); i++)
        {
            int selection = Random.Range(0, petData.GetIngredients().Count);
            for (int j = 0; j < petData.GetIngredients().Count; j++)
            {
                if (resourceManager_script.instance.Convert(petData.GetIngredients()[j]).GetAmount() <= 0)
                {
                    selection = j;
                    break;
                }
            }
            ingredient_scriptable ingredient = resourceManager_script.instance.Convert(petData.GetIngredients()[selection]);
            ingredient.Add(amtGain);
            print(ingredient.name + " --> " + amtGain.ToString());
            if (Indicator != null && soundManager_script.instance.current_page == 0)
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
        SoundHandling();
    }

    void SoundHandling()
    {
        if (soundManager_script.instance.current_page == 0)
        {
            petsounds.volume = 1;
        }
        else
        {
            petsounds.volume = 0.25f;
        }
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
        float waitSeconds = petData.GetEatCooldown();
        while (true)
        {
            yield return new WaitForSeconds(waitSeconds);
            if (resourceManager_script.instance.EatFood(petData.GetConsumptionAmount())) 
            {
                GainResource();
                resourceManager_script.instance.UpdateUI();
                waitSeconds = petData.GetEatCooldown();
            }
            else
            {
                GainResource();
                waitSeconds = petData.GetEatCooldown() * 3;
            }
        }
    }
}
