using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool canOpen;
    public bool isOpen;

    public int pumpkins;
    public int wheat;

    private void Start()
    {
        canOpen = true;
    }
    public void AddItem(Crops cropType)
    {
        switch (cropType)
        { 
            case Crops.Wheat:
                wheat++;
                CustomEventSystem.customEventSystem.InventoryChange(cropType, wheat);
                break;
            case Crops.Pumpkin:
                pumpkins++;
                CustomEventSystem.customEventSystem.InventoryChange(cropType, pumpkins);
                break;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            OpenInv();
        }
    }
    public void OpenInv()
    {
        CustomEventSystem.customEventSystem.InventoryOpened();
    }
}
