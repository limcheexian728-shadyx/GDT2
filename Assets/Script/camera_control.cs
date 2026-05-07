using UnityEngine;

public class camera_control : MonoBehaviour
{

    [SerializeField] private float camTravelSpeed = 5;

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
    }

    public void SwitchScreen(int newScreen)
    {
        targetPosition = screenPosition[newScreen];
    }
}
