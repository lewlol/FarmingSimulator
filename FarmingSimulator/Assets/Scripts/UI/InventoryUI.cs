using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventory;

    public TextMeshProUGUI pumpkinCount;
    public TextMeshProUGUI wheatCount;
    public void Start()
    {
        CustomEventSystem.customEventSystem.OnInventoryChange += ChangeUI;
    }

    public void ChangeUI(Crops cropType, int amount)
    {
        switch (cropType) 
        {
            case Crops.Pumpkin:
                pumpkinCount.text = amount.ToString(); 
                break;
            case Crops.Wheat:
                wheatCount.text = amount.ToString();
                break;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool inventoryOpen = inventory.activeSelf;
            inventory.SetActive(!inventoryOpen);
        }
    }
}
