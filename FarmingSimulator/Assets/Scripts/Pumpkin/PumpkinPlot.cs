using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PumpkinPlot : MonoBehaviour
{
    public GameObject pumpkinPrefab;
    public Transform[] pumpkinSpots;
    public bool[] pumpkinBools;
    bool full;

    [Range(0, 100)]public float pumpkinChance;
    private void Start()
    {
        CustomEventSystem.customEventSystem.OnTickEvent += TrySpawnPumpkin;
    }
    private void SpawnPumpkin()
    {
        int spawnPoint = Random.Range(0, pumpkinSpots.Length);
        if (pumpkinBools[spawnPoint] == true)
        {
            SpawnPumpkin();
            return;
        }

        Vector3 spawnPos = pumpkinSpots[spawnPoint].position;
        pumpkinBools[spawnPoint] = true;
        GameObject pumpkin = Instantiate(pumpkinPrefab, spawnPos, Quaternion.identity);

        pumpkin.GetComponent<PumpkinPickup>().plot = this;
        pumpkin.GetComponent<PumpkinPickup>().boolNumber = spawnPoint;
    }

    private void TrySpawnPumpkin()
    {
        full = pumpkinBools.All(pumpkinSpots => pumpkinSpots);
        if (full)
            return;

        float c = Random.Range(0, 100);
        if(c <= pumpkinChance)
        {
            SpawnPumpkin();
        }
    }

    public void ResetBool(int boolNumber)
    {
        pumpkinBools[boolNumber] = false;
    }
}
