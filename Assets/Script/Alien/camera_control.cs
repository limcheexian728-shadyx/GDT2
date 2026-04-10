using UnityEngine;

public class camera_control : MonoBehaviour
{
    [SerializeField] private Vector3 alienScreenPosition;
    [SerializeField] private Vector3 bakeryScreenPosition;
    [SerializeField] private float camTravelSpeed = 5;

    private bool alienScreen;

    void Start()
    {
        if (alienScreen) transform.position = alienScreenPosition;
        else transform.position = bakeryScreenPosition;
    }

    void Update()
    {
        if (alienScreen)
            transform.position = Vector3.Lerp(transform.position, alienScreenPosition, camTravelSpeed * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, bakeryScreenPosition, camTravelSpeed * Time.deltaTime);
    }

    public void SwitchScreen(bool toAlien)
    {
        alienScreen = toAlien;
    }
}
