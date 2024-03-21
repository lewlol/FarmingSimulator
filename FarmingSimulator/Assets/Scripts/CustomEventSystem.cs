using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem customEventSystem;

    private void Start()
    {
        customEventSystem = this;
    }

    public event Action OnTickEvent;
    public void TickEvent()
    {
        if(OnTickEvent != null)
        {
            OnTickEvent();
        }
    }

    public event Action<bool, int> OnChangeCoins; //Add Coins with this
    public void ChangeCoins(bool plus, int amount)
    {
        if(OnChangeCoins != null)
        {
            OnChangeCoins(plus, amount);
        }
    }

    public event Action<int> OnCoinsChanged; //This updated COIN UI
    public void CoinsChanged(int amount)
    {
        if(OnCoinsChanged != null)
        {
            OnCoinsChanged(amount);
        }
    }

    public event Action<Crops, int> OnInventoryChange;
    public void InventoryChange(Crops cropType, int amount)
    {
        if(OnInventoryChange != null)
        {
            OnInventoryChange(cropType, amount);
        }
    }

    public event Action OnInventoryOpened;
    public void InventoryOpened()
    {
        if(OnInventoryOpened != null)
        {
            OnInventoryOpened();
        }
    }

    public event Action<bool> OnTurnOffPlayerUI;
    public void TurnOffPlayerUI(bool on)
    {
        if(OnTurnOffPlayerUI != null)
        {
            OnTurnOffPlayerUI(on);
        }
    }
}
