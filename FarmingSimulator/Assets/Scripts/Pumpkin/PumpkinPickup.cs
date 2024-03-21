using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinPickup : MonoBehaviour
{
    public Crops cropType;
    public int boolNumber;
    public PumpkinPlot plot;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Inventory>().AddItem(cropType, 1);
            plot.ResetBool(boolNumber);

            //Destroy
            Destroy(gameObject);
        }
    }
}
