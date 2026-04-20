using UnityEngine;

public class RubbishBinScript : MonoBehaviour
{
    public BakeryManager BakeryBoss;

    public void Diu()
    {
        BakeryBoss.CakeAmount = false;
        BakeryBoss.ChocolateJamAmount = false;
        BakeryBoss.CherryAmount = false;
    }
}
