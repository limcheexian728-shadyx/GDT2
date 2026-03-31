using UnityEngine;

public class CakeScript : MonoBehaviour
{
    BakeryManager Chef;
    public int WhoAreYou;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Chef = GameObject.FindGameObjectWithTag("Chef").GetComponent<BakeryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        switch (WhoAreYou)
        {
            case 0:
                break;
            case 1:
                Chef.CakeAmount += 1;
                break;
            case 2:
                Chef.ChocolateJamAmount += 1;
                break;
            case 3:
                Chef.CherryAmount += 1;
                break;
            default:
                break;
        }
    }
}
