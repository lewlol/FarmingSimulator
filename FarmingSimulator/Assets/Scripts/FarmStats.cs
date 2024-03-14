using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmStats : MonoBehaviour
{
    [Range(0, 100)] public float globalGrowthChance;

    [Range(0, 100)] public float wheatGrowthChance;
    [Range(0, 100)] public float pumpkinGrowthChance;
}
