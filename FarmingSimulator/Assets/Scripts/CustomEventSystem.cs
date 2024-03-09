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

    public event Action<bool, int> OnChangeCoins;
    public void ChangeCoins(bool plus, int amount)
    {
        if(OnChangeCoins != null)
        {
            OnChangeCoins(plus, amount);
        }
    }

    public event Action<int> OnCoinsChanged;
    public void CoinsChanged(int amount)
    {
        if(OnCoinsChanged != null)
        {
            OnCoinsChanged(amount);
        }
    }
}
