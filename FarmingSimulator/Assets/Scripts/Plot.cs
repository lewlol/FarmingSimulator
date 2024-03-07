using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public bool isCleared;
    public int plotID;
    public CropData cropData;
    GameObject currentPlot;

    public GameObject grass;
    public GameObject tilled;

    public void SpawnCropPlot(CropData cd)
    {
        //Detroy Previous Crop Plot First and Unsubscribe its Event
        if(currentPlot != null)
        {
            Destroy(currentPlot);
        }

        //New Crop Data
        cropData = cd;

        //Change Plot Floor
        switch (cropData.floorTile) 
        {
            case Tiles.Grass:
                Grass();
                break;
            case Tiles.Tilled:
                Till();
                break;
            case Tiles.Sand:
                //Sand
                break;
        }

        //Instantiate Crop Plot
        GameObject newPlot = Instantiate(cropData.cropPlot, transform.position, Quaternion.identity);
        currentPlot = newPlot;
    }
    public void Till()
    {
        grass.SetActive(false);
        tilled.SetActive(true);
    }

    public void Grass()
    {
        grass.SetActive(true);
        tilled.SetActive(false);
    }
}
