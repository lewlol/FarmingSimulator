using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{

    public TextMeshProUGUI coinsText;

    private void Start()
    {
        CustomEventSystem.customEventSystem.OnCoinsChanged += CoinUIChange;
    }
    public void CoinUIChange(int amount)
    {
        coinsText.text = amount.ToString() + " Coins";
    }
}
