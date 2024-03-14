using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Visitor")]
public class VisitorData : ScriptableObject
{
    [Header("Information")]
    public string visitorName;
    public GameObject visitorModel;

    [Header("Trade Information")]
    public Crops[] possibleCrops;

    public int minAskAmount;
    public int maxAskAmount;

    public int minCoinReward;
    public int maxCoinReward;
}
