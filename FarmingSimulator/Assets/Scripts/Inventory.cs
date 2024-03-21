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
    public void AddItem(Crops cropType, int amount)
    {
        switch (cropType)
        { 
            case Crops.Wheat:
                wheat += amount;
                CustomEventSystem.customEventSystem.InventoryChange(cropType, wheat);
                break;
            case Crops.Pumpkin:
                pumpkins += amount;
                CustomEventSystem.customEventSystem.InventoryChange(cropType, pumpkins);
                break;
        }

    }

    public void RemoveItem(Crops cropType, int amount)
    {
        switch (cropType)
        {
            case Crops.Wheat:
                wheat -= amount;
                CustomEventSystem.customEventSystem.InventoryChange(cropType, wheat);
                break;
            case Crops.Pumpkin:
                pumpkins -= amount;
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
