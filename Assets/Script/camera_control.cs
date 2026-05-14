using UnityEngine;

public class camera_control : MonoBehaviour
{

    [SerializeField] private float camTravelSpeed = 5;
    [SerializeField] Transform Overlay;

    [Header("Screens")]
    [SerializeField] private int startScreen = 2;
    [SerializeField] private Vector3[] screenPosition = new Vector3[5];
    private Vector3 targetPosition;

    void Start()
    {
        SwitchScreen(startScreen);
        transform.position = targetPosition;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, camTravelSpeed * Time.deltaTime);
        Overlay.position = transform.position + Vector3.forward;
    }

    public void SwitchScreen(int newScreen)
    {
        targetPosition = screenPosition[newScreen];
        if (soundManager_script.instance != null)
            soundManager_script.instance.current_page = newScreen;
    }
}
