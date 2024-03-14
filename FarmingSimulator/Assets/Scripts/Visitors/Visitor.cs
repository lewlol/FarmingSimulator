using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visitor : MonoBehaviour
{
    public VisitorData vData;

    public int askAmount;
    public int coinReward;
    public Crops crop;

    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
        SetTrade();
    }

    private void SetTrade()
    {
        //Set Crop Type
        int c = Random.Range(0, vData.possibleCrops.Length);
        crop = vData.possibleCrops[c];

        //Amount to Ask For
        askAmount = Random.Range(vData.minAskAmount, vData.maxAskAmount);

        //Rewards
        coinReward = Random.Range(vData.minCoinReward, vData.maxCoinReward);
    }

    public void AcceptRequest()
    {
        if (player != null)
        {
            switch (crop)
            {
                case Crops.Wheat:
                    player.GetComponent<Inventory>().wheat -= askAmount; break;
                case Crops.Pumpkin:
                    player.GetComponent<Inventory>().pumpkins -= askAmount; break;
            }

            player.GetComponent<Coins>().coins += coinReward;

            DeleteObject();
        }
    }

    public void DenyRequest()
    {
        if (player != null)
        {
            DeleteObject();
        }
    }

    private void DeleteObject()
    {
        Destroy(gameObject);
    }
}
