using UnityEngine;

public class camera_control : MonoBehaviour
{
    [SerializeField] private Vector3 alienScreenPosition;
    [SerializeField] private Vector3 bakeryScreenPosition;
    [SerializeField] private float camTravelSpeed;

    private bool alienScreen;

    void Start()
    {
        
    }

    void Update()
    {
        if (alienScreen)
            transform.position = Vector3.Lerp(transform.position, alienScreenPosition, camTravelSpeed);
        else
            transform.position = Vector3.Lerp(transform.position, bakeryScreenPosition, camTravelSpeed);
    }

    public void SwitchScreen(bool toAlien)
    {
        alienScreen = toAlien;
    }
}
