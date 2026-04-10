using UnityEngine;

public class camera_control : MonoBehaviour
{
    [SerializeField] private float camTravelSpeed = 5;

    [Header("Alien")]
    [SerializeField] private RectTransform alienButton;
    [SerializeField] private Vector3 alienScreenPosition;

    [Header("Bakery")]
    [SerializeField] private RectTransform bakeryButton;
    [SerializeField] private Vector3 bakeryScreenPosition;

    private bool alienScreen;
    private Vector3 showButton = new Vector3(10, 0, 0);
    private Vector3 hideButton = new Vector3(50, 0, 0);

    void Start()
    {
        if (alienScreen) transform.position = alienScreenPosition;
        else transform.position = bakeryScreenPosition;
    }

    void Update()
    {
        if (alienScreen)
        {
            transform.position = Vector3.Lerp(transform.position, alienScreenPosition, camTravelSpeed * Time.deltaTime);
            alienButton.anchoredPosition = Vector3.Lerp(alienButton.anchoredPosition, -hideButton, camTravelSpeed * Time.deltaTime);
            bakeryButton.anchoredPosition = Vector3.Lerp(bakeryButton.anchoredPosition, -showButton, camTravelSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, bakeryScreenPosition, camTravelSpeed * Time.deltaTime);
            alienButton.anchoredPosition = Vector3.Lerp(alienButton.anchoredPosition, showButton, camTravelSpeed * Time.deltaTime);
            bakeryButton.anchoredPosition = Vector3.Lerp(bakeryButton.anchoredPosition, hideButton, camTravelSpeed * Time.deltaTime);
        }
    }

    public void SwitchScreen(bool toAlien) { alienScreen = toAlien; }
}
