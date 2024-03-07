using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotMenu : MonoBehaviour
{
    public Image[] plotIcons;
    public Plot[] plots;
    int c;

    private void Awake()
    {
        ChangeIconColour();
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
        }
        c = 0;
    }
}
