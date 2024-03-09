using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotMenu : MonoBehaviour
{
    public GameObject pasteMenu;

    public Image[] plotIcons;
    public Image[] icons;
    public Plot[] plots;
    int c;
    int x;
    int currentID;
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
        foreach(Image i in icons)
        {
            if(plots[x].cropData != null)
            {
                switch (plots[x].cropData.cropType)
                {
                    case Crops.None:
                        i.enabled = false;
                        break;
                    case Crops.Wheat:
                        i.enabled = true;
                        break;
                    case Crops.Pumpkin:
                        i.enabled = true;
                        break;
                }
            }
            else
            {
                i.enabled = false;
            }
            x++;
        }
        x = 0;
    }

    public void ClickToClear(int id)
    {
        foreach(Plot p in plots)
        {
            if (id == p.plotID)
            {
                if (p.isCleared == true)
                {
                    ClickToPaste(p.plotID);
                }

                p.isCleared = true;
            }
        }
        ChangeIconColour();
        ChangePlotIcons();
    }

    public void ClickToPaste(int id)
    {
        currentID = id - 1;
        //Open Paste Menu
        pasteMenu.SetActive(true);
    }

    public void PasteCropPlot(CropData cd)
    {
        plots[currentID].SpawnCropPlot(cd);

        ChangeIconColour();
        ChangePlotIcons();

        pasteMenu.SetActive(false);
    }

    public void TurnOffMenu()
    {
        gameObject.SetActive(false);
    }
}
