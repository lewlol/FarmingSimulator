using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Visitor Settings")]
public class VisitorSettings : ScriptableObject
{
    public float commonChance;
    public float uncommonChance;
    public float rareChance;
    public float epicChance;
    public float legendaryChance;
    public float mythicChance;
    public float iconicChance;
}
