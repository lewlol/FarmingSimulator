using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WheatPlot : MonoBehaviour
{
    public GameObject wheatPrefab;
    public Transform[] wheatSpots;
    public bool[] wheatBools;
    bool full;

    public Crops cropType = Crops.Wheat;

    [Range(0, 100)] public float wheatChance;

    private void Start()
    {
        CustomEventSystem.customEventSystem.OnTickEvent += TrySpawnWheat;
    }
    public void SpawnWheat()
    {
        int spawnPoint = Random.Range(0, wheatSpots.Length);
        if (wheatBools[spawnPoint] == true)
        {
            SpawnWheat();
            return;
        }

        Vector3 spawnPos = wheatSpots[spawnPoint].position;
        wheatBools[spawnPoint] = true;
        GameObject wheat = Instantiate(wheatPrefab, spawnPos, Quaternion.identity);

        wheat.GetComponent<WheatPickup>().plot = this;
        wheat.GetComponent<WheatPickup>().boolNumber = spawnPoint;
    }

    public void TrySpawnWheat()
    {
        full = wheatBools.All(ws => ws);
        if (full)
            return;

        float c = Random.Range(0, 100);
        if(c <= wheatChance)
        {
            SpawnWheat();
        }

    }

    public void ResetBool(int boolNumber)
    {
        wheatBools[boolNumber] = false;
    }

    public void OnDestroy()
    {
        CustomEventSystem.customEventSystem.OnTickEvent -= TrySpawnWheat;
    }
}