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
    private Vector3 alienShowButton = new Vector3(15, 350, 0);
    private Vector3 alienHideButton = new Vector3(-80, 350, 0);
    private Vector3 bakeryShowButton = new Vector3(-15, 350, 0);
    private Vector3 bakeryHideButton = new Vector3(80, 350, 0);

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
            //alienButton.anchoredPosition = Vector3.Lerp(alienButton.anchoredPosition, alienHideButton, camTravelSpeed * Time.deltaTime);
            //bakeryButton.anchoredPosition = Vector3.Lerp(bakeryButton.anchoredPosition, bakeryShowButton, camTravelSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, bakeryScreenPosition, camTravelSpeed * Time.deltaTime);
            //alienButton.anchoredPosition = Vector3.Lerp(alienButton.anchoredPosition, alienShowButton, camTravelSpeed * Time.deltaTime);
            //bakeryButton.anchoredPosition = Vector3.Lerp(bakeryButton.anchoredPosition, bakeryHideButton, camTravelSpeed * Time.deltaTime);
        }
    }

    public void SwitchScreen(bool toAlien) { alienScreen = toAlien; }
}
