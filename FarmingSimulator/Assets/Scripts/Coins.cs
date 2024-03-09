using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coins;

    private void Start()
    {
        CustomEventSystem.customEventSystem.OnChangeCoins += EditCoinCount;
    }
    public void AddCoins(int amount)
    {
        coins += amount;
        CustomEventSystem.customEventSystem.CoinsChanged(coins);
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
        CustomEventSystem.customEventSystem.CoinsChanged(coins);
    }

    public void EditCoinCount(bool plus, int amount)
    {
        if(plus)
            AddCoins(amount);
        else
            RemoveCoins(amount);
    }
}
