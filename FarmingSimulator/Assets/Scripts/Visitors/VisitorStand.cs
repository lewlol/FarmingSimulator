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
    public Transform 

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
        GameObject visitor = Instantiate(visitorPrefab, )
    }
}
