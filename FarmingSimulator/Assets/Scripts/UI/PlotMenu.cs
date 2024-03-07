using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotMenu : MonoBehaviour
{
    public Image[] plotIcons;
    public Plot[] plots;
    int c;
    int x;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        ChangeIconColour();
        ChangePlotIcons();
    }
    private void ChangeIconColour()
    {
        foreach(Image pi in plotIcons)
        {
            if (!plots[c].isCleared)
            {
                pi.color = Color.red;
            }
            else if (plots[c].isCleared)
            {
                pi.color = Color.yellow;
            }
            c++;
        }
        c = 0;
    }

    private void ChangePlotIcons()
    {
        foreach(Image i in plotIcons)
        {
            Image icon = i.GetComponentInChildren<Image>();
            switch (plots[c].currentCrop)
            { 
                case Crops.None:
                    icon.enabled = false;
                    break;
                case Crops.Wheat:
                    icon.enabled = true;
                    break;
                case Crops.Pumpkin:
                    icon.enabled = true;
                    break;
            }
            x++;
        }
        c = 0;
    }

    public void ClickToClear(int id)
    {
        foreach(Plot p in plots)
        {
            if (id == p.plotID)
            {
                p.isCleared = true;
            }
        }
        ChangeIconColour();
        ChangePlotIcons();
    }
}
