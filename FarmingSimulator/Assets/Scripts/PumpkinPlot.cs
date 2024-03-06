using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinPlot : MonoBehaviour
{
    public GameObject pumpkinPrefab;
    public Transform[] pumpkinSpots;
    private void SpawnPumpkin()
    {
        float x = Random.Range(transform.position.x - 10, transform.position.x + 10);
        float z = Random.Range(transform.position.z - 10, transform.position.z + 10);
        Vector3 spawnPos = new Vector3 (x, 0.5f, z);

        Instantiate(pumpkinPrefab, spawnPos, Quaternion.identity);
    }
}
