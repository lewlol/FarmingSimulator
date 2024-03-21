using JetBrains.Annotations;
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

   public bool GetCropValue(Crops cropType, int amount)
    {
        if(cropType == Crops.Wheat)
        {
            if(amount <= wheat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }else if(cropType == Crops.Pumpkin)
        {
            if (amount <= pumpkins)
            {
                return true;
            }
            else
            {
                return false;
            }
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
