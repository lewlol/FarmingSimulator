using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeMenuUI : MonoBehaviour
{
    //Ask
    public TextMeshProUGUI askAmount;
    public Image cropSprite;

    //Reward
    public TextMeshProUGUI coinReward;
    public void SetMenuValues(int ask, Sprite crop, int coins)
    {
        askAmount.text = ask.ToString();
        cropSprite.sprite = crop;
        coinReward.text = coins.ToString();
    }
}
