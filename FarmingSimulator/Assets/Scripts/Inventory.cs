using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int pumpkins;
    public int wheat;

    public void AddItem(Crops cropType)
    {
        switch (cropType)
        { 
            case Crops.Wheat:
                wheat++;
                break;
            case Crops.Pumpkin:
                pumpkins++;
                break;
        }

    }
}