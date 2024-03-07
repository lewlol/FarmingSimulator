using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CropData")]
public class CropData : ScriptableObject
{
    public Crops cropType;
    public GameObject cropPlot;
    public Tiles floorTile;
}
