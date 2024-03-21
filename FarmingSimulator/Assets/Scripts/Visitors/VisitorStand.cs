using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorStand : MonoBehaviour
{
    public bool unlocked;
    public bool available;

    public VisitorData[] visitors;
    public VisitorSettings vSettings;

    VisitorData activeVisitor;

    float vCooldown = 10;
    float c;

    public GameObject visitorPrefab;
    public Transform spawnPos;

    GameObject visitorObj;

    bool canOpenMenu;
    public GameObject tradeMenu;

    //Trade Stuff
    public int askAmount;
    public int coinReward;
    public Crops crop;

    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (unlocked && available)
        {
            float cdown = c -= Time.deltaTime;
            if (cdown <= 0)
            {
                RaritySelect();
                c = vCooldown;
                available = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canOpenMenu)
            {
                OpenTradeMenu();
            }
        }    
    }

    private void RaritySelect()
    {
        int r = Random.Range(0, 1000);

        if(r <= vSettings.commonChance && r > vSettings.uncommonChance)
        {
            ChooseVisitor(Rarity.Common);
        }
        else if(r <= vSettings.uncommonChance && r > vSettings.rareChance)
        {
            ChooseVisitor(Rarity.Uncommon);
        }
        else if (r <= vSettings.rareChance && r > vSettings.epicChance)
        {
            ChooseVisitor(Rarity.Rare);
        }
        else if (r <= vSettings.epicChance && r > vSettings.legendaryChance)
        {
            ChooseVisitor(Rarity.Epic);
        }
        else if (r <= vSettings.legendaryChance && r > vSettings.mythicChance)
        {
            ChooseVisitor(Rarity.Legendary);
        }
        else if (r <= vSettings.mythicChance && r > vSettings.iconicChance)
        {
            ChooseVisitor(Rarity.Mythic);
        }
        else
        {
            ChooseVisitor(Rarity.Iconic);
        }
    }


    private void ChooseVisitor(Rarity rarity)
    {
        int v = Random.Range(0, visitors.Length);
        if (visitors[v].rarity == rarity)
        {
            activeVisitor = visitors[v];
            SpawnVisitor();
        }
        else
        {
            ChooseVisitor(rarity);
        }
    }

    private void SpawnVisitor()
    {
        visitorObj = Instantiate(visitorPrefab, spawnPos.position, Quaternion.identity);
        SetTrade();
    }

    private void OpenTradeMenu()
    {
        tradeMenu.SetActive(true);

        tradeMenu.GetComponent<TradeMenuUI>().SetMenuValues(askAmount, null, coinReward);

        Cursor.lockState = CursorLockMode.None;
    }
    private void SetTrade()
    {
        //Set Crop Type
        int c = Random.Range(0, activeVisitor.possibleCrops.Length);
        crop = activeVisitor.possibleCrops[c];

        //Amount to Ask For
        askAmount = Random.Range(activeVisitor.minAskAmount, activeVisitor.maxAskAmount);

        //Rewards
        coinReward = Random.Range(activeVisitor.minCoinReward, activeVisitor.maxCoinReward);
    }

    public void AcceptRequest()
    {
        if (player != null)
        {
            player.GetComponent<Inventory>().RemoveItem(crop, askAmount);

            CustomEventSystem.customEventSystem.ChangeCoins(true, coinReward);

            tradeMenu.SetActive(false);
            Destroy(visitorObj);

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void DenyRequest()
    {
        tradeMenu.SetActive(false);
        Destroy(visitorObj);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Allow the Open of Menu
            canOpenMenu = true;

            //Stop Inventory
            collision.gameObject.GetComponent<Inventory>().canOpen = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Deny Open Menu
            canOpenMenu = false;

            //Allow Inventory
            other.gameObject.GetComponent<Inventory>().canOpen = true;
        }
    }
}
